using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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