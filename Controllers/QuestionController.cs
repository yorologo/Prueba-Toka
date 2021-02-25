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
    public class QuestionController : Controller
    {
        private readonly BlogContext _context;
        public QuestionController(BlogContext context)
        {
            _context = context;
        }

        // POST: Question/CreateQuestion
        [HttpPost]
        public IActionResult CreateQuestion()
        {
            return View();
        }
        // POST: Question/AnswerQuestion
        [HttpPost]
        public IActionResult QuestionQuestion()
        {
            return View();
        }
        // POST: Question/EditQuestion
        [HttpPost]
        public IActionResult EditQuestion()
        {
            return View();
        }
        // GET: Question/DeleteQuestion/{questionId}/{answerId}
        public IActionResult DeleteQuestion()
        {
            return View();
        }
    }
}