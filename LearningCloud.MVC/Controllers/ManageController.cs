//using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNet;
using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Host.SystemWeb;
using LearningCloud.Infra.CrossCutting.Identity.Configuration;
using LearningCloud.Infra.CrossCutting.Identity.Model.ManageViewModels;

namespace LearningCloud.MVC.Controllers
{
    public class ManageController : Controller
    {
         private readonly ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public ManageController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        //
        // GET: /Manage/Index
        public async Task<ActionResult> Index(ManageMessageId? message)
        {
            ViewBag.StatusMessage =
                message == ManageMessageId.ChangePasswordSuccess ? "A senha foi alterada."
                : message == ManageMessageId.SetPasswordSuccess ? "A senha foi enviada."
                : message == ManageMessageId.SetTwoFactorSuccess ? "A segunda validação foi enviada."
                : message == ManageMessageId.Error ? "Ocorreu um erro."
                : message == ManageMessageId.AddPhoneSuccess ? "O Telefone foi adicionado."
                : message == ManageMessageId.RemovePhoneSuccess ? "O Telefone foi removido."
                : "";

            var userId = User.Identity.GetUserId();
            var model = new IndexViewModel
            {
                HasPassword = HasPassword(),
                PhoneNumber = await _userManager.GetPhoneNumberAsync(userId),
                TwoFactor = await _userManager.GetTwoFactorEnabledAsync(userId),
                Logins = await _userManager.GetLoginsAsync(userId),
                BrowserRemembered = await AuthenticationManager.TwoFactorBrowserRememberedAsync(userId)
            };
            return View(model);
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

        private bool HasPassword()
        {
            var user = _userManager.FindById(User.Identity.GetUserId());
            if (user != null)
            {
                return user.PasswordHash != null;
            }
            return false;
        }

        public enum ManageMessageId
        {
            AddPhoneSuccess,
            ChangePasswordSuccess,
            SetTwoFactorSuccess,
            SetPasswordSuccess,
            RemoveLoginSuccess,
            RemovePhoneSuccess,
            Error
        }

        #endregion
    }
}