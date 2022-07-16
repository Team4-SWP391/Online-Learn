using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;

namespace Online_Learn.Controllers
{
    public class LessonController : Controller
    {
        private readonly Online_LearnContext _context;

        public LessonController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Lesson
    


  

        // GET: Lesson/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lesson = await _context.Lessons.FindAsync(id);
            if (lesson == null)
            {
                return NotFound();
            }
            ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureName", lesson.LectureId);
            return View(lesson);
        }

        // POST: Lesson/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LessonId,LessonName,Video,Main,LectureId")] Lesson lesson)
        {
           
            var lecture = await _context.Lectures.FirstOrDefaultAsync(x => x.LectureId == lesson.LectureId);
            if (id != lesson.LessonId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lesson);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LessonExists(lesson.LessonId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return Redirect($"/Lecture/Detail?id={lecture.LectureId}");
            }
            ViewData["LectureId"] = new SelectList(_context.Lectures, "LectureId", "LectureName", lesson.LectureId);
            return View(lesson);
        }

 

        private bool LessonExists(int id)
        {
            return _context.Lessons.Any(e => e.LessonId == id);
        }



        // GET: Lesson/VideoPage/5
        public async Task<IActionResult> VideoPage(int? id, int?courseid)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lessons = await _context.Lessons.FirstOrDefaultAsync(l => l.LessonId == id);

            if (lessons == null)
            {
                return NotFound();
            }

            int owner = 0;
            var account_id = JsonSerializer.Deserialize<Account>(HttpContext.Session.GetString("User")).AccountId;
            var ac = _context.AccountCourses.FirstOrDefault(x => x.AccountId == account_id && x.CourseId == id);
            if (ac != null)
            {
                owner = 1;
            }




            //var course = _context.Courses.FirstOrDefault(c => c.CourseId == courseid);
            //var lectures = from l in _context.Lectures
            //               join c in _context.Courses on l.CourseId equals c.CourseId
            //               join les in _context.Lessons on l.LectureId equals les.LectureId
            //               where les.LessonId == id where l.CourseId == course.CourseId
            //               select l;
            var lectures = _context.Lectures.Where(x => x.LectureId ==lessons.LectureId).ToList();

            ViewBag.lesson = lessons;

            ViewBag.lectures = lectures;

            //var lesson = (from l in lectures
            //              join les in _context.Lessons on l.LectureId equals les.LectureId
            //              join co in _context.Courses on l.CourseId equals co.CourseId
            //              where l.CourseId == co.CourseId
            //              select les).ToList();
            //ViewBag.lessons = lesson;
            ViewBag.owner = owner;

            return View();
        }
    }
}
