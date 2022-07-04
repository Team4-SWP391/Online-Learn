using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.Contracts.Messaging;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Online_Learn.Models;

namespace Online_Learn.Controllers {
    public class ExamController : Controller {
        private readonly Online_LearnContext _context;

        public ExamController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Exam
        public async Task<IActionResult> Index(int quantity)
        {
            List<Question> list = _context.Questions.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            return View(list);
        }


        //Post: Exam/ViewResult
        [HttpPost]
        public async Task<IActionResult> ViewResult(ListResult[] listRes, string time, int examId, int totalQuestion)
        {
            int result = 0;
            foreach (var item in listRes)
            {
                string solution = _context.Questions.Where(x => x.QuestionId == item.id).FirstOrDefault().Solution;
                if (solution == item.answer)
                {
                    result++;
                }
            }
            double pointEachQuestion = (double)totalQuestion / listRes.Length;
            double score = Convert.ToDouble(pointEachQuestion.ToString("0.00")) * result;
            await _context.Results.AddAsync(new Result
            {
                ExamId = examId,
                Score = score,
                CorrectAnswer = result,
                Status = score >= 5 ? "Pass" : "Not Pass",
                Time = Convert.ToInt32(time)
            });
            await _context.SaveChangesAsync();
            int length = _context.Results.Count();
            int id = _context.Results.OrderByDescending(x => x.ResultId).First().ResultId;
            return Json(new { url = Url.Action("ViewResult", "Exam", new { id = id }) });
        }

        [HttpGet]
        public IActionResult ViewResult(int id)
        {
            var Result = _context.Results.ToList().FirstOrDefault(x => x.ResultId == id);
            int? totalQuestion = _context.Exams.FirstOrDefault(x => x.ExamId == Result.ExamId).Quantity;
            ViewBag.Result = Result;
            ViewBag.totalQuestion = totalQuestion;
            return View();
        }
    }
    public class ListResult {
        public int id { get; set; }
        public string answer { get; set; }
    }
}
