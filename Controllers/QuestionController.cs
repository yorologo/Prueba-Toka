using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<int>> CreateQuestion([Bind("Name,Email,Password")] Question question)
        {

            question.IdUser = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();

            if (ModelState.IsValid)
            {
                _context.Add(question);
                var IdQuestion = await _context.SaveChangesAsync();
                return IdQuestion;
            }

            return BadRequest();
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