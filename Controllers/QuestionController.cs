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

        // Get: Question/Question
        public IActionResult Question()
        {
            return View();
        }
        // POST: Question/Question
        [HttpPost]
        public async Task<IActionResult> Question([Bind("Id,Name,Email,Password")] Question question)
        {
            var IdUser = HttpContext.User.Claims.Where(c => c.Type == ClaimTypes.Sid)
                   .Select(c => c.Value).SingleOrDefault();

            if (IdUser == null)
            {
                return Redirect("Home/Login");
            }

            if (question.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    _context.Add(question);
                    var IdQuestion = await _context.SaveChangesAsync();

                    return Redirect("/Question/Question/" + IdQuestion);
                }
                return View(question);
            }
            else
            {
                var findQuestion = await _context.Questions.FindAsync(question.Id);
                if (findQuestion != null)
                {
                    if (findQuestion.IdUser == IdUser)
                    {
                        findQuestion.Tittle = question.Tittle;
                        findQuestion.Body = question.Body;
                        _context.SaveChanges();

                        return Redirect("/Question/Question/" + findQuestion.Id);
                    }
                }
            }

            return NotFound();
        }
        // GET: Question/Ask/{id}
        public async Task<IActionResult> Ask(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);

            return View(question);
        }
        // GET: Question/DeleteQuestion/{questionId}
        public async Task<IActionResult> DeleteQuestion(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var question = await _context.Questions.FindAsync(id);
            _context.Questions.Remove(question);
            await _context.SaveChangesAsync();

            return Redirect("/");
        }
    }
}