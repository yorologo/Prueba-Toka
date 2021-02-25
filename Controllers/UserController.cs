using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba_toka.Models;

namespace prueba_toka.Controllers
{
    public class UserController : Controller
    {
        // POST: User/CreateUser
        public IActionResult CreateUser()
        {
            return View();
        }
        // GET: User/Logout
        public IActionResult Logout()
        {
            return View();
        }
        // POST: User/ValidateUser
        public IActionResult ValidateUser()
        {
            return View();
        }
    }
}