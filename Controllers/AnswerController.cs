using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prueba_toka.Models;
using Prueba_Toka.DAL;

namespace prueba_toka.Controllers
{
    public class AnswerController : Controller
    {
        private readonly BlogContext _context;
        public AnswerController(BlogContext context)
        {
            _context = context;
        }
        
        // POST: Answer/CreateAnswer
        [HttpPost]
        public IActionResult CreateAnswer()
        {
            var Id = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();
            return View();
        }

        // POST: Answer/EditAnswer
        [HttpPost]
        public IActionResult EditAnswer()
        {
            return View();
        }
        // GET: Question/MarkAnswer/{questionId}/{answerId}
        public IActionResult MarkAnswer()
        {
            return View();
        }
        // GET: Answer/DeleteAnswer/{questionId}/{answerId}
        public IActionResult DeleteAnswer()
        {
            return View();
        }

    }
}