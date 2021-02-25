using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba_toka.Models;

namespace prueba_toka.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: Home/Register
        public IActionResult Register()
        {
            return View();
        }
        // GET: Home/Login
        public IActionResult Login()
        {
            return View();
        }
        // GET: Home/Ask
        public IActionResult Ask()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
    }
}
