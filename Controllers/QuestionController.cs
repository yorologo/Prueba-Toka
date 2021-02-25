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
    public class QuestionController : Controller
    {
        // POST: Question/CreateQuestion
        public IActionResult CreateQuestion()
        {
            return View();
        }
        // POST: Question/AnswerQuestion
        public IActionResult QuestionQuestion()
        {
            return View();
        }
        // POST: Question/EditQuestion
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