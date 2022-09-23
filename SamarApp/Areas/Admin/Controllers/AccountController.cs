using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SamarApp.Models;
using System.Threading.Tasks;
using DAL;
namespace SamarApp.Areas.Admin.Controllers
{


    [Area("Admin")]
    public class AccountController : Controller
    {
        public UserManager<ApplicationUser> _UserManager { get; }
        public SignInManager<ApplicationUser> _SignInManager { get; }

        public AccountController(UserManager<ApplicationUser> userManager , SignInManager<ApplicationUser> signInManager)
        {
            _UserManager=userManager;
            _SignInManager=signInManager;
        }


        #region Register

        [HttpGet]
        public IActionResult Register()
        {
            return View();  
        }

        [HttpPost]
        public async  Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.UserName,
                    Email = model.Email,
                    IsAgree = model.IsAgree,
                };

                var Result = await _UserManager.CreateAsync(user , model.Password);

                if (Result.Succeeded)
                    return RedirectToAction(nameof(Login));

                foreach (var error in Result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
               
                return View (model);

            }
            return View (model);
        }

        #endregion

        #region Login
       
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel  model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByNameAsync(model.UserName);
               
                if (user != null)
                {
                    if (model.Password.Equals("Samar@21") ||model.Password.Equals("reham@21") || model.Password.Equals("Mina@21"))
                    {
                        var password = await _UserManager.CheckPasswordAsync(user, model.Password);
                        if (password)
                        {
                            var result = await _SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                            if (result.Succeeded)
                                return RedirectToAction("Index", "Admins");
                        }
                    }
                    else
                    {
                        var password = await _UserManager.CheckPasswordAsync(user, model.Password);
                        if (password)
                        {
                            var result = await _SignInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                            if (result.Succeeded)
                                return RedirectToAction("Index", "Home" , new { UserName = model.UserName });
                        }
                    }
                }
            }
            return View(model);
        }

        #endregion

        #region SignOut

        public async new Task<IActionResult> SignOut()
        {
            await _SignInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }

        #endregion


        #region Forget Password
        [HttpGet]
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgetPassword(ForgetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                
                var user = await _UserManager.FindByEmailAsync(model.Email);
               
                if (user != null)
                {
                    var Token = await _UserManager.GeneratePasswordResetTokenAsync(user);
                    var PasswordResetLink = Url.Action("ResetPassword", "Account", new { Email = user.Email, Token = Token }, Request.Scheme);

                    var Email = new Email()
                    {
                        Title = "Reset Password",
                        To = model.Email,
                        Body = PasswordResetLink
                    };
                    EmailSettings.SendEmail(Email);
                   
                    return RedirectToAction(nameof(CompleteForgetPassword));
                }
                ModelState.AddModelError(string.Empty, "This Email is not Exist");
            }
            return View(model);
        }

        public IActionResult CompleteForgetPassword()
        {
            return View();
        }

        #endregion





        #region Reset Password
        public IActionResult ResetPassword(string email, string token)
        {
            //var user = await _UserManager.FindByEmailAsync(email);
            //if (user == null)
            //    return BadRequest();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _UserManager.FindByEmailAsync(model.Email);
                if (user != null)
                {
                    var result = await _UserManager.ResetPasswordAsync(user, model.Token, model.Password);
                    if (result.Succeeded)
                        return RedirectToAction(nameof(Login));
                    foreach (var error in result.Errors)
                        ModelState.AddModelError(string.Empty, error.Description);
                }
                ModelState.AddModelError(string.Empty, "Invalid Email");
            }
            return View(model);
            }

            #endregion

        }
}
