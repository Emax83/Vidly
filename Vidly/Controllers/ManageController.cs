using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
    
namespace Vidly.Controllers
{
    [CustomAuth(Roles = "SuperAdmin")]
    public class ManageController : BaseController
    {
        // GET: Manage
        public ActionResult Index()
        {
            return View();
        }
    }
}