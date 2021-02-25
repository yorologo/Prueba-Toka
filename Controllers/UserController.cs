using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using prueba_toka.Models;
using Prueba_Toka.DAL;

namespace prueba_toka.Controllers
{
    public class UserController : Controller
    {
        private readonly BlogContext _context;
        public UserController(BlogContext context)
        {
            _context = context;
        }

        // POST: User/CreateUser
        [HttpPost]
        public async Task<IActionResult> CreateUser([Bind("Name,Email,Password")] User user)
        {
            if (ModelState.IsValid)
            {
                var findUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == user.Email);
                if (findUser == null)
                {
                    _context.Add(user);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Login", "Home");
                }
            }

            return Redirect("/Home/Register");
        }
        // POST: User/ValidateUser
        [HttpPost]
        public async Task<IActionResult> ValidateUser([Bind("Email,Password")] User user)
        {
            var findUser = await _context.Users
                .FirstOrDefaultAsync(m => m.Email == user.Email);
            if (findUser.Password == user.Password)
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, findUser.Id.ToString()));
                claims.Add(new Claim(ClaimTypes.Name, findUser.Name));
                ClaimsIdentity identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(principal);

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login", "Home");
        }
        // GET: User/Logout
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}