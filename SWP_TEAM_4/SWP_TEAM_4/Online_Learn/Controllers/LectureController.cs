using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Online_Learn.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Online_Learn.Controllers
{
    public class LectureController : Controller
    {
        private readonly Online_LearnContext _context;

        public LectureController(Online_LearnContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Detail(int id)
        {
            var lecture = await _context.Lectures.FirstOrDefaultAsync(x => x.LectureId == id);
            var course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == lecture.CourseId);
            var lessons = await _context.Lessons.Where(x => x.LectureId == id).ToListAsync();
            var total_lesson = lessons.Count;
            ViewBag.course = course;
            ViewBag.lecture = lecture;
            ViewBag.lessons = lessons;
            ViewBag.total_lesson = total_lesson;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Detail(Lecture NewLecture)
        {
            var lecture = await _context.Lectures.Where(x => x.LectureId == NewLecture.LectureId).FirstOrDefaultAsync();
            if(lecture != null)
            {
                lecture.LectureName = NewLecture.LectureName;
                lecture.Description = NewLecture.Description;
                await _context.SaveChangesAsync();
            }
            return Redirect($"Detail?id={lecture.LectureId}");
        }

        public async Task<IActionResult> Delete(int id)
        {
            var lecture = await _context.Lectures.Where(x => x.LectureId == id).FirstOrDefaultAsync();
            if(lecture != null)
            {
                  _context.Lectures.Remove(lecture);
                  _context.SaveChanges();
            }
            return Redirect($"../Course/Edit?id={lecture.CourseId}");
        }

    }
}
