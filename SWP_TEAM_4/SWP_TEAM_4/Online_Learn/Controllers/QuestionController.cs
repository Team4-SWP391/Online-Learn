using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

using Microsoft.AspNetCore.Mvc;

using Online_Learn.Models;

namespace Online_Learn.Controllers {
    public class QuestionController : Controller {
        private readonly Online_LearnContext _context;

        public QuestionController(Online_LearnContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            List<Question> questionsSlider = _context.Questions.ToList();
            List<Question> questions = _context.Questions.Take(3).ToList();
            model.questionsSlider = questionsSlider;
            model.questions = questions;
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit(int id, string quiz, string op1, string op2, string op3, string op4, string solution, int totalQuestion)
        {
            Question question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);
            question.Quiz = quiz;
            question.Op1 = op1;
            question.Op2 = op2;
            question.Op3 = op3;
            question.Op4 = op4;
            question.Solution = solution;
            _context.Update(question);
            _context.SaveChanges();
            List<Question> questions = new List<Question>();
            if (totalQuestion == 3)
            {
                questions = _context.Questions.Take(3).ToList();
            }
            else
            {
                questions = _context.Questions.ToList();

            }
            return PartialView("QuestionPartial", questions);
        }

        public IActionResult Delete(int id)
        {
            Question question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);
            _context.Remove(question);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult LoadMore()
        {
            List<Question> questions = _context.Questions.ToList();
            return PartialView("QuestionPartial", questions);
        }
    }
}
