using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Vidly.Infrastracture;
using Vidly.ViewModels;
using Vidly.Infrastracture.Authentication;

namespace Vidly.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService service)
        {
            _userService = service;
        }

        // GET: Account
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {

            return View();
        }

        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            ViewData["returnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (string.IsNullOrEmpty(vm.Email) || string.IsNullOrEmpty(vm.Password))
                    {
                        ModelState.AddModelError("", "Insert credentials");
                        return View();
                    }

                    var user = _userService.Login(vm.Email, vm.Password);
                    if (user == null)
                    {
                        ModelState.AddModelError("", "Invalid credentials");
                        return View();
                    }

                    AuthenticationManager.Logon(user, vm.RememberMe);

                    if (!string.IsNullOrEmpty(vm.ReturnUrl))
                        return Redirect(vm.ReturnUrl);

                    return RedirectToAction("Index", "Home", new { area = "" });
                }
                catch(Exception ex)
                {
                    AddError("Login Error: " + ex.Message);
                }

               
            }
            else
            {
                ModelState.AddModelError("","Compilare tutte i campi");
            }
            return View();
        }
            

        [HttpGet]
        public ActionResult Logout()
        {
            AuthenticationManager.Logoff();
            return RedirectToAction("Index", "Home",new { area=""});
        }

        [HttpGet]
        public ActionResult Register()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(FormCollection form)
        {
            return RedirectToAction("Details");
        }

        [HttpGet]
        public ActionResult ChangePassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(FormCollection form)
        {

            return View();
        }

        [HttpGet]
        public ActionResult RecoverPassword()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult RecoverPassword(FormCollection form)
        {

            return View();
        }

        [HttpGet]
        public ActionResult ActivateAccount(string activationCode)
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ActivateAccount(string activationCode, FormCollection form)
        {

            return View();
        }

    }
}