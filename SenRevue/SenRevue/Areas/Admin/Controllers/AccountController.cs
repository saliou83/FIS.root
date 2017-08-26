using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using SenRevue.Areas.Admin.Models.Account;
using SenRevue.Helpers;
using SenRevue.Areas.Admin.Models.ViewModel;

namespace SenRevue.Areas.Admin.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            var model = new LoginViewModel();
            model.Title = LabelHelpers.GetLabel("admin_login_title");
            ViewBag.ReturnUrl = Url.Action("Index", "Admin", new { Area = "Admin", languageCode = model.DefaultLang });
            return View(model);
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            //Supprimer un utilisateur
            //await DeleteUser("fallsaliou23@gmail.com");
            //await DeleteUser("admin@senrevue.com");
            if (!ModelState.IsValid)
            {
                model.Title = LabelHelpers.GetLabel("admin_login_title");
                return View(model);
            }

            // Ceci ne comptabilise pas les échecs de connexion pour le verrouillage du compte
            // Pour que les échecs de mot de passe déclenchent le verrouillage du compte, utilisez shouldLockout: true
            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
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
                    ModelState.AddModelError("", LabelHelpers.GetLabel("login_fail"));
                    return View(model);
            }
        }

        //
        // GET: /Account/VerifyCode
        [AllowAnonymous]
        public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        {
            // Nécessiter que l'utilisateur soit déjà connecté via un nom d'utilisateur/mot de passe ou une connexte externe
            if (!await SignInManager.HasBeenVerifiedAsync())
            {
                return View("Error");
            }
            return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/VerifyCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Le code suivant protège des attaques par force brute contre les codes à 2 facteurs. 
            // Si un utilisateur entre des codes incorrects pendant un certain intervalle, le compte de cet utilisateur 
            // est alors verrouillé pendant une durée spécifiée. 
            // Vous pouvez configurer les paramètres de verrouillage du compte dans IdentityConfig
            var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
            switch (result)
            {
                case SignInStatus.Success:
                    return RedirectToLocal(model.ReturnUrl);
                case SignInStatus.LockedOut:
                    return View("Lockout");
                case SignInStatus.Failure:
                default:
                    ModelState.AddModelError("", "Code non valide.");
                    return View(model);
            }
        }

        //
        // GET: /Account/Register
        [Authorize(Roles ="Admin")]
        public ActionResult Register()
        {
            var model = new RegisterViewModel();
            model.Title = LabelHelpers.GetLabel("admin_register_title");
            return View(model);
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
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    var idManager = new IdentityManager();
                    if (!idManager.RoleExists(model.Role))
                    {
                        idManager.CreateRole(model.Role);
                    }
                    idManager.AddUserToRole(user.Id, model.Role);
                    //await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);

                    // Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
                    // Envoyer un message électronique avec ce lien
                    string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                    var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                    await UserManager.SendEmailAsync(user.Id, LabelHelpers.GetLabel("page_confirm_mail_title"), string.Format(LabelHelpers.GetLabel("page_confirm_mail_content"), callbackUrl));

                    model = new RegisterViewModel()
                    {
                        ConfirmationMessage = string.Format(LabelHelpers.GetLabel("confirm_user_created_message"), model.Email)
                    };

                    //return RedirectToAction("Index", "Home");
                }
                else
                {
                    AddErrors(result);
                    model.ErrorMessage = string.Join("<br />", result.Errors);
                }
            }
            model.Title = LabelHelpers.GetLabel("admin_register_title");

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            return View(model);
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code)
        {
            var model = new ConfirmEmailViewModel();
            model.Title = LabelHelpers.GetLabel("mail_confirm_mail_title");
            if (userId == null || code == null)
            {
                return View("Error");
            }

            var result = await UserManager.ConfirmEmailAsync(userId, code);

            string codeReInit = await UserManager.GeneratePasswordResetTokenAsync(userId);
            model.ChangePasswordLink = Url.Action("ResetPassword", "Account", new { userId = userId, code = codeReInit }, protocol: Request.Url.Scheme);

            return View(result.Succeeded ? "ConfirmEmail" : "Error", model);
        }

        //
        // GET: /Account/ForgotPassword
        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            var model = new ForgotPasswordViewModel();
            model.Title = LabelHelpers.GetLabel("forgot_password_title");
            return View(model);
        }

        //
        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null || !(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    // Ne révélez pas que l'utilisateur n'existe pas ou qu'il n'est pas confirmé
                    return View("ForgotPasswordConfirmation");
                }

                //Pour plus d'informations sur l'activation de la confirmation du compte et la réinitialisation du mot de passe, consultez http://go.microsoft.com/fwlink/?LinkID=320771
                // Envoyer un message électronique avec ce lien
                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                await UserManager.SendEmailAsync(user.Id, "Réinitialiser le mot de passe", "Réinitialisez votre mot de passe en cliquant <a href=\"" + callbackUrl + "\">ici</a>");
                return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }

            // Si nous sommes arrivés là, un échec s’est produit. Réafficher le formulaire
            model.Title = LabelHelpers.GetLabel("forgot_password_title");
            return View(model);
        }

        //
        // GET: /Account/ForgotPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ForgotPasswordConfirmation()
        {
            return View();
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            var model = new ResetPasswordViewModel();
            model.Title = LabelHelpers.GetLabel("reset_password_title");
            return code == null ? View("Error", model) : View(model);
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            model.Title = LabelHelpers.GetLabel("reset_password_title");
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Ne révélez pas que l'utilisateur n'existe pas
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View(model);
        }

        //
        // GET: /Account/ResetPasswordConfirmation
        [AllowAnonymous]
        public ActionResult ResetPasswordConfirmation()
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                Title = LabelHelpers.GetLabel("reset_password_title")
            };
            return View(model);
        }

        //
        // POST: /Account/ExternalLogin
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ExternalLogin(string provider, string returnUrl)
        {
            // Demandez une redirection vers le fournisseur de connexions externe
            return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        }

        //
        // GET: /Account/SendCode
        [AllowAnonymous]
        public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe)
        {
            var userId = await SignInManager.GetVerifiedUserIdAsync();
            if (userId == null)
            {
                return View("Error");
            }
            var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(userId);
            var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
            return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });
        }

        //
        // POST: /Account/SendCode
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(SendCodeViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            // Générer le jeton et l'envoyer
            if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
            {
                return View("Error");
            }
            return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
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

            // Connecter cet utilisateur à ce fournisseur de connexion externe si l'utilisateur possède déjà une connexion
            var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
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
                    // Si l'utilisateur n'a pas de compte, invitez alors celui-ci à créer un compte
                    ViewBag.ReturnUrl = returnUrl;
                    ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
                    return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
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
                // Obtenez des informations sur l’utilisateur auprès du fournisseur de connexions externe
                var info = await AuthenticationManager.GetExternalLoginInfoAsync();
                if (info == null)
                {
                    return View("ExternalLoginFailure");
                }
                var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
                var result = await UserManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    result = await UserManager.AddLoginAsync(user.Id, info.Login);
                    if (result.Succeeded)
                    {
                        await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
                        return RedirectToLocal(returnUrl);
                    }
                }
                AddErrors(result);
            }

            ViewBag.ReturnUrl = returnUrl;
            return View(model);
        }

        //
        // POST: /Account/LogOff
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Login", new { returnUrl = "" });
        }

        //
        // GET: /Account/ExternalLoginFailure
        [AllowAnonymous]
        public ActionResult ExternalLoginFailure()
        {
            return View();
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

        #region Applications auxiliaires
        // Utilisé(e) pour la protection XSRF lors de l'ajout de connexions externes
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

        /// <summary>
        /// Supprimer un utilisateur
        /// </summary>
        /// <param name="mail"></param>
        public async Task<bool> DeleteUser(string mail)
        {
            var user = UserManager.FindByEmail(mail);
            var logins = user.Logins;
            var rolesForUser = await UserManager.GetRolesAsync(user.Id);
            foreach (var login in logins.ToList())
            {
                await UserManager.RemoveLoginAsync(login.UserId, new UserLoginInfo(login.LoginProvider, login.ProviderKey));
            }

            if (rolesForUser.Count() > 0)
            {
                foreach (var item in rolesForUser.ToList())
                {
                    // item should be the name of the role
                    var result = await UserManager.RemoveFromRoleAsync(user.Id, item);
                }
            }

            await UserManager.DeleteAsync(user);
            return true;
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