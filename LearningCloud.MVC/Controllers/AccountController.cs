using System;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using LearningCloud.Infra.CrossCutting.Identity.Models;
using LearningCloud.Infra.CrossCutting.Identity.Models.AccountViewModels;
using LearningCloud.Infra.CrossCutting.Identity.Configuration;
using LearningCloud.Application.Interfaces;

using System.Linq;
using System.Globalization;
using System.Security.Claims;

namespace LearningCloud.MVC.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;
        private readonly IUsuarioAcessoAppService _usuarioAcessoApp;

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager, IUsuarioAcessoAppService usuarioAcessoApp)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _usuarioAcessoApp = usuarioAcessoApp;
        }

        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            string userName = _usuarioAcessoApp.GetLoginByEmailOrUser(model.UserName);

            if (userName != null)
            {
                model.UserName = userName;
            }

            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, change to shouldLockout: true
            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, shouldLockout: true);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = model.RememberMe });
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Login ou Senha incorretos.");
                    return View(model);
            }
        }

        
        // GET: /Account/Register
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    uac_usuario = new Domain.Entities.Usuario
                    {
                        usu_nome = model.Nome,
                        usu_sobreNome = model.Sobrenome,
                        usu_nivel = 30,
                        usu_dataNascimento = model.DataNascimento,
                        usu_dataCadastro = DateTime.Now.ToUniversalTime(),
                        usu_status = "A"
                    }
                };
                
                var existingAccount = await _userManager.FindByNameAsync(user.UserName);

                if (existingAccount != null && existingAccount.Id != user.Id)
                    ModelState.AddModelError("UserName", "O Usuário '" + user.UserName + "' já existe.");

                var existingEmail = await _userManager.FindByEmailAsync(user.Email);

                if (existingEmail != null && existingEmail.Id != user.Id)
                {
                    ModelState.AddModelError("Email", "O Email '" + user.Email + "' já existe.");
                    user.EmailConfirmed = false;
                }

                var result = await _userManager.CreateAsync(user, model.ConfirmPassword);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await _userManager.SendEmailAsync(user.Id, "Confirme sua Conta", "Por favor confirme sua conta clicando neste link: <a href='" + callbackUrl + "'></a>");
                    ViewBag.Link = callbackUrl;
                    return View("DisplayEmail");
                }
                AddErrors(result);
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return View("Error");
            }
            var result = await _userManager.ConfirmEmailAsync(userId, code);
            return View(result.Succeeded ? "ConfirmEmail" : "Error");
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Request a redirect to the external login provider
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/ExternalLoginCallback
        [AllowAnonymous]
        public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        {


            var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
            if (loginInfo == null)
            {
                return RedirectToAction("Login");
            }

            // Sign in the user with this external login provider if the user already has a login
            var result = await _signInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(returnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.RequiresVerification:
                    return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
                case SignInStatus.Failure:
                default:
                    // Se ele nao tem uma conta solicite que crie uma
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;

                    //get firstname, lastname and email address from login provider
                    var providerKey = loginInfo.Login.ProviderKey;
                    var loginProvider = loginInfo.Login.LoginProvider;

                    var addtionalDetail = await ExternalClaimsManager.GetAddtionalLoginDetailsAsync(
                                                                        loginProvider,
                                                                        AuthenticationManager.GetExternalIdentityAsync(DefaultAuthenticationTypes.ExternalCookie)
                                                                        );


                    // Pegar a informação do login externo.
                    var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                    if (info == null)
                    {
                        return View("ExternalLoginFailure");
                    }

                    var user = new ApplicationUser
                    {

                        UserName = loginInfo.DefaultUserName.ToLower(),
                        Email = loginInfo.Email,
                        EmailConfirmed = true,
                        uac_usuario = new Domain.Entities.Usuario
                        {
                            usu_nome = addtionalDetail.FirstName,
                            usu_sobreNome = addtionalDetail.LastName,
                            usu_nivel = 30,
                            usu_dataCadastro = DateTime.Now.ToUniversalTime(),
                            usu_status = "A"
                        }


                    };

                    //   _userManager.UserValidator = new CustomUserValidator<ApplicationUser>(_userManager);

                    //if (String.IsNullOrEmpty(user.UserName))
                    //{
                    //    ModelState.AddModelError("UserName", "Preencha o campo Usuário.");
                    //}
                    //else
                    //{
                        var existingAccount = await _userManager.FindByNameAsync(user.UserName);

                        if (existingAccount != null && existingAccount.Id != user.Id)
                            ModelState.AddModelError("UserName", "O Usuário '" + user.UserName + "' já existe.");

                        var existingEmail = await _userManager.FindByEmailAsync(user.Email);

                        if (existingEmail != null && existingEmail.Id != user.Id)
                        {
                            ModelState.AddModelError("Email", "O Email '" + user.Email + "' já existe.");
                            user.EmailConfirmed = false;
                        }
                    //}

                    var resultCreate = await _userManager.CreateAsync(user);
                    if (resultCreate.Succeeded)
                    {
                        resultCreate = await _userManager.AddLoginAsync(user.Id, info.Login);
                        if (resultCreate.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                            return RedirectToLocal(returnUrl);
                        }
                    }
                    AddErrors(resultCreate);
  
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { UserName = user.UserName, Nome = user.uac_usuario.usu_nome, Sobrenome = user.uac_usuario.usu_sobreNome, Email = user.Email });

            }
           
        }


        //
        // POST: /Account/ExternalLoginConfirmation
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Manage");
            }

            if (ModelState.IsValid)
            {
                // Pegar a informação do login externo.
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }

                ViewBag.ReturnUrl = returnUrl;
                ViewBag.LoginProvider = info.Login.LoginProvider;


                var user = new ApplicationUser { 
                
                
        
                    UserName = model.UserName,
                    Email = model.Email,
                    uac_usuario = new Domain.Entities.Usuario
                    {
                        usu_nome = model.Nome,
                        usu_sobreNome = model.Sobrenome,
                        usu_nivel = 30,
                        usu_dataCadastro = DateTime.Now.ToUniversalTime(),
                        usu_status = "A"
                    }
         

                };

                var existingAccount = await _userManager.FindByNameAsync(user.UserName);

                if (existingAccount != null && existingAccount.Id != user.Id)
                    ModelState.AddModelError("UserName", "O Usuário '" + user.UserName + "' já existe.");

                var existingEmail = await _userManager.FindByEmailAsync(user.Email);

                if (existingEmail != null && existingEmail.Id != user.Id)
                {
                    ModelState.AddModelError("Email", "O Email '" + user.Email + "' já existe.");
                    user.EmailConfirmed = false;
                }


                var result = await _userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await _userManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }


        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
        }

        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }

                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }


        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}