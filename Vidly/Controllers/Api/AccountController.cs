using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.Infrastracture;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class AccountController : ApiController
    {
        private readonly IUserService _userService;
        public AccountController(IUserService service)
        {
            _userService = service;
        }

        public IHttpActionResult Login(string username, string password, bool remember)
        {
            return null;
        }
    }
}