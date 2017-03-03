using System;
using System.Web.Mvc;
using Owin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.DataProtection;
using LearningCloud.Infra.CrossCutting.Identity.Configuration;
using LearningCloud.Infra.CrossCutting.Identity.Models;


using Microsoft.Owin.Security.Google;
using Microsoft.Owin.Security.Facebook;
using Newtonsoft.Json.Linq;
//using Newtonsoft.Json.Linq;
using System.Security.Claims;



//[assembly: OwinStartup(typeof(LearningCloud.MVC.Startup))]

namespace LearningCloud.MVC
{
    public partial class Startup
    {
        public static IDataProtectionProvider DataProtectionProvider { get; set; }

        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301864
        public void ConfigureAuth(IAppBuilder app)
        {



            const string FacebookClaimBaseName = "urn:facebook:{0}";
            const string GoogleClaimBaseName = "urn:google:{0}";
            const string TwitterClaimBaseName = "urn:twitter:{0}";
            const string TwitterTokensBaseName = "urn:tokens:twitter:";

            ////string TwitterAccessToken = TwitterTokensBaseName + "accesstoken";
            ////string TwitterAccessTokenSecret = TwitterTokensBaseName + "accesstokensecret";

            ////string FacebookClaimLink = String.Format(FacebookClaimBaseName, "link");
            ////string FacebookClaimId = String.Format(FacebookClaimBaseName, "id");
            ////string FacebookClaimEmail = String.Format(FacebookClaimBaseName, "email");
            ////string FacebookClaimFirstName = String.Format(FacebookClaimBaseName, "first_name");
            ////string FacebookClaimLastName = String.Format(FacebookClaimBaseName, "last_name");
            ////string FacebookClaimGender = String.Format(FacebookClaimBaseName, "gender");
            ////string FacebookClaimLocale = String.Format(FacebookClaimBaseName, "locale");
            ////string FacebookClaimTimeZone = String.Format(FacebookClaimBaseName, "timezone");
            ////string FacebookClaimUpdatedTime = String.Format(FacebookClaimBaseName, "updated_time");
            ////string FacebookClaimVerified = String.Format(FacebookClaimBaseName, "verified");
            ////string FacebookClaimBirthday = String.Format(FacebookClaimBaseName, "user_birthday");

            ////string GoogleClaimProfile = String.Format(GoogleClaimBaseName, "profile");
            ////string GoogleClaimSub = String.Format(GoogleClaimBaseName, "sub");
            ////string GoogleClaimName = String.Format(GoogleClaimBaseName, "name");
            ////string GoogleClaimGivenName = String.Format(GoogleClaimBaseName, "given_name");
            ////string GoogleClaimFamilyName = String.Format(GoogleClaimBaseName, "family_name");
            ////string GoogleClaimPicture = String.Format(GoogleClaimBaseName, "picture");
            ////string GoogleClaimEmail = String.Format(GoogleClaimBaseName, "email");
            ////string GoogleClaimEmailVerified = String.Format(GoogleClaimBaseName, "email_verified");
            ////string GoogleClaimGender = String.Format(GoogleClaimBaseName, "gender");
            ////string GoogleClaimLocale = String.Format(GoogleClaimBaseName, "locale");

            ////string TwitterClaimUserId = String.Format(TwitterClaimBaseName, "userid");
            ////string TwitterClaimScreenName = String.Format(TwitterClaimBaseName, "screenname");




            // Configure the db context, user manager and signin manager to use a single instance per request
            app.CreatePerOwinContext(() => DependencyResolver.Current.GetService<ApplicationUserManager>());

            // Enable the application to use a cookie to store information for the signed in user
            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
            // Configure the sign in cookie
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
                Provider = new CookieAuthenticationProvider
                {
                    // Enables the application to validate the security stamp when the user logs in.
                    // This is a security feature which is used when you change a password or add an external login to your account.  
                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
                        validateInterval: TimeSpan.FromMinutes(30),
                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
                }
            });
            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

            // Enables the application to remember the second login verification factor such as phone or email.
            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
            // This is similar to the RememberMe option when you log in.
            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);


            //app.MapSignalR();

            // Uncomment the following lines to enable logging in with third party login providers
            //http://localhost:24332/Account/ExternalLoginCallback
            ///
            //app.UseMicrosoftAccountAuthentication(
            //    clientId: "00000000481D1F5F",
            //    clientSecret: "2wcUbjL3Lrh8c786qFbXtbu");

            //app.UseTwitterAuthentication(
            //   consumerKey: "",
            //   consumerSecret: "");




            const string xmlSchemaString = "http://www.w3.org/2001/XMLSchema#string";

            string facebookAppId = "217851345348916";
            string facebookAppSecret = "3a4369eecd8d978baa476a1fb9e964c5";

            var facebookOptions = new FacebookAuthenticationOptions();
            facebookOptions.AppId = facebookAppId;
            facebookOptions.AppSecret = facebookAppSecret;
            facebookOptions.Scope.Add("email");
            //facebookOptions.Scope.Add("user_birthday");
            facebookOptions.BackchannelHttpHandler = new FacebookBackChannelHandler();
            facebookOptions.UserInformationEndpoint = "https://graph.facebook.com/v2.7/me?fields=id,name,email,first_name,last_name";
            facebookOptions.Provider = new FacebookAuthenticationProvider()
            {
                OnAuthenticated = async facebookContext =>
                {
                    // Save every additional claim we can find in the user
                    foreach (JProperty property in facebookContext.User.Children())
                    {
                        var claimType = string.Format(FacebookClaimBaseName, property.Name);
                        string claimValue = (string)property.Value;
                        if (!facebookContext.Identity.HasClaim(claimType, claimValue))
                            facebookContext.Identity.AddClaim(new Claim(claimType, claimValue, xmlSchemaString, "External"));
                    }

                }
            };
            facebookOptions.SignInAsAuthenticationType = DefaultAuthenticationTypes.ExternalCookie;
            app.UseFacebookAuthentication(facebookOptions);


            //app.UseFacebookAuthentication(
            //   appId: "217851345348916",
            //   appSecret: "3a4369eecd8d978baa476a1fb9e964c5");


            string googleClientId = "359134327838-37rl59j06tjpc29ltbsrmpem66sk809a.apps.googleusercontent.com";
            string googleClientSecret = "9TM5TEiUS6e2Egjqh5deumdp";

            var googleAuthenticationOptions = new GoogleOAuth2AuthenticationOptions
            {
                ClientId = googleClientId,
                ClientSecret = googleClientSecret,
                Provider = new GoogleOAuth2AuthenticationProvider()
                {
                   //OnAuthenticated = async googleContext =>
                   // {
                   //  //   string profileClaimName = string.Format("urn:google:{0}", "profile");
                   //     foreach (JProperty property in googleContext.User.Children())
                   //     {
                   //         var claimType = string.Format(GoogleClaimBaseName, property.Name);
                   //         string claimValue = (string)property.Value;
                   //         if (!googleContext.Identity.HasClaim(claimType, claimValue))
                   //             googleContext.Identity.AddClaim(new Claim(claimType, claimValue,
                   //                   xmlSchemaString, "External"));
                   //     }
                   // }
               }
            };
            googleAuthenticationOptions.Scope.Add("https://www.googleapis.com/auth/plus.login");
            googleAuthenticationOptions.Scope.Add("https://www.googleapis.com/auth/userinfo.email");
            app.UseGoogleAuthentication(googleAuthenticationOptions);




            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
            //{
            //    ClientId = "359134327838-37rl59j06tjpc29ltbsrmpem66sk809a.apps.googleusercontent.com",
            //    ClientSecret = "9TM5TEiUS6e2Egjqh5deumdp"
            //});
        }

        public class FacebookBackChannelHandler : System.Net.Http.HttpClientHandler
        {
            protected override async System.Threading.Tasks.Task<System.Net.Http.HttpResponseMessage> SendAsync(System.Net.Http.HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                // Replace the RequestUri so it's not malformed
                if (!request.RequestUri.AbsolutePath.Contains("/oauth"))
                {
                    request.RequestUri = new Uri(request.RequestUri.AbsoluteUri.Replace("?access_token", "&access_token"));
                }

                return await base.SendAsync(request, cancellationToken);
            }
        }
    }
}
