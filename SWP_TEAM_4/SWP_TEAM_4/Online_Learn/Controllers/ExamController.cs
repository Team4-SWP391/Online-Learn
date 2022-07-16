using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;

namespace Online_Learn.Controllers
{
    public class ExamController : Controller
    {
        private readonly Online_LearnContext _context;

        public ExamController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Do Exam
        public async Task<IActionResult> Index(int quantity)
        {
            List<Question> list = _context.Questions.OrderBy(x => Guid.NewGuid()).Take(10).ToList();
            return View(list);
        }


        //Post: Do Exam/ViewResult
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

        // GET: Exams
        public async Task<IActionResult> List()
        {
            var online_LearnContext = _context.Exams.Include(e => e.Lecture);
            //var examName = _context.Exams.Include(e => e.ExamName);
            //ViewBag.examName = examName;
            return View(await online_LearnContext.ToListAsync());
        }

        // GET: Exams/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Lecture)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }

            return View(exam);
        }

        // GET: Exams/Create
        public IActionResult Create()
        {
            ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ExamId,ExamName,Quantity,Time,StartDate,LectureId")] Exam exam)
        {
            var lecture = await _context.Lectures.Where(x => x.LectureId == exam.LectureId).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                _context.Add(exam);
                await _context.SaveChangesAsync();
                return Redirect($"../Course/Edit?id={lecture.CourseId}");
            }
            ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureName", exam.LectureId);
            return Redirect($"../Course/Edit?id={lecture.CourseId}");
        }

        // GET: Exams/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var exam = await _context.Exams.FindAsync(id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureName", exam.LectureId);
            ViewData["ExamId"] = id;
            ViewData["ExamName"] = exam.ExamName;
            ViewData["Quantity"] = exam.Quantity;
            ViewData["Time"] = exam.Time;
            ViewData["Lecture"] = exam.LectureId;
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]

        public async Task<IActionResult> Edit(int id, [Bind("ExamId,ExamName,Quantity,Time,StartDate,LectureId")] Exam exam)
        {
            var lecture = await _context.Lectures.Where(x => x.LectureId == exam.LectureId).FirstOrDefaultAsync();
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(exam);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExamExists(exam.ExamId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"../Course/Edit?id={lecture.CourseId}");
            }
            ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureName", exam.LectureId);
            return Redirect($"../Course/Edit?id={lecture.CourseId}");
        }

        // GET: Exams/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var exam = await _context.Exams
                .Include(e => e.Lecture)
                .FirstOrDefaultAsync(m => m.ExamId == id);
            if (exam == null)
            {
                return NotFound();
            }
            ViewData["ExamId"] = exam.ExamId;
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Exam exam = await _context.Exams.FirstOrDefaultAsync(x => x.ExamId == id);
            var lecture = await _context.Lectures.Where(x => x.LectureId == exam.LectureId).FirstOrDefaultAsync();

            //var exam = await _context.Exams.FindAsync(id);
            _context.Exams.Remove(exam);
            await _context.SaveChangesAsync();
            return Redirect($"../Course/Edit?id={lecture.CourseId}");
        }

        private bool ExamExists(int id)
        {
            return _context.Exams.Any(e => e.ExamId == id);
        }
    }
    public class ListResult
    {
        public int id { get; set; }
        public string answer { get; set; }
    }
}
