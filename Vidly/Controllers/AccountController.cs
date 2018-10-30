using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Infrastracture;

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
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection form)
        {

            return RedirectToAction("Index","Home", new { area = "" });
        }

        [HttpGet]
        public ActionResult Logout()
        {

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