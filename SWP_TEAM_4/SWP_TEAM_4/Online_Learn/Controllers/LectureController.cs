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
    public class LectureController : Controller
    {
        private readonly Online_LearnContext _context;

        public LectureController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Lecture
        public async Task<IActionResult> Index()
        {
            var online_LearnContext = _context.Lectures.Include(l => l.Course);
            return View(await online_LearnContext.ToListAsync());
        }

        // GET: Lecture/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures
                .Include(l => l.Course)
                .FirstOrDefaultAsync(m => m.LectureId == id);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["id"] = lecture.LectureId;

            return View(lecture);
        }

        // GET: Lecture/Create
        public IActionResult Create()
        {
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName");
            return View();
        }

        // POST: Lecture/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LectureId,LectureName,CourseId,CreateAt,Description")] Lecture lecture)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lecture);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lecture/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lecture = await _context.Lectures.FindAsync(id);
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // POST: Lecture/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LectureId,LectureName,CourseId,CreateAt,Description")] Lecture lecture)
        {
            if (id != lecture.LectureId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lecture);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LectureExists(lecture.LectureId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CourseId"] = new SelectList(_context.Courses, "CourseId", "CourseName", lecture.CourseId);
            return View(lecture);
        }

        // GET: Lecture/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var lecture = await _context.Lectures
            //    .Include(l => l.Course)
            //    .FirstOrDefaultAsync(m => m.LectureId == id);
            var lecture = await _context.Lectures.FindAsync(id);
            _context.Lectures.Remove(lecture);
            await _context.SaveChangesAsync();
          
            if (lecture == null)
            {
                return NotFound();
            }
            ViewData["id"] = lecture.LectureId;

            return RedirectToAction(nameof(Index));
           

        }

        // POST: Lecture/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var lecture = await _context.Lectures.FindAsync(id);
        //    _context.Lectures.Remove(lecture);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        private bool LectureExists(int id)
        {
            return _context.Lectures.Any(e => e.LectureId == id);
        }
    }
}
