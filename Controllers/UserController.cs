using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
                    user.Password = EncryptPassword(user.Password);
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
            if (IsEqualPassword(user.Password, findUser.Password))
            {
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.Sid, findUser.Id.ToString(), ClaimValueTypes.Integer));
                claims.Add(new Claim(ClaimTypes.Name, findUser.Name, ClaimValueTypes.String));
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

        private string EncryptPassword(string password)
        {
            byte[] salt = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Array.Copy(salt, 0, hashBytes, 0, 16);
            Array.Copy(hash, 0, hashBytes, 16, 20);

            return Convert.ToBase64String(hashBytes);
        }
        private bool IsEqualPassword(string password, string passwordHashed)
        {
            byte[] hashBytes = Convert.FromBase64String(passwordHashed);

            byte[] salt = new byte[16];
            Array.Copy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                    return false;
            }
            return true;
        }
    }
}