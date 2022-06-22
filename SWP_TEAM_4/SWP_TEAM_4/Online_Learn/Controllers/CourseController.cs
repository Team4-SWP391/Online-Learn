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
    public class CourseController : Controller
    {
        private readonly Online_learnContext _context;

        public CourseController(Online_learnContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var online_learnContext = _context.Courses.Include(c => c.Account).Include(c => c.Department).Include(c => c.Level);
            return View(await online_learnContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Account)
                .Include(c => c.Department)
                .Include(c => c.Level)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CourseName"] = course.CourseName;
            ViewData["CourseDesc"] = course.Description;
            ViewData["CourseImage"] = course.Image;
            ViewData["CoursePrice"] = course.Price;
            ViewData["CourseDepartment"] = course.Department.DepartmentName;
            return View(course);
        }

        // GET: Courses/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "LevelId");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CourseId,CourseName,Price,DepartmentId,Image,Rate,Language,AccountId,Description,IsSale,UpdateAt,LevelId")] Course course)
        {
            if (ModelState.IsValid)
            {
                _context.Add(course);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", course.AccountId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "LevelId", course.LevelId);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.FindAsync(id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", course.AccountId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "LevelId", course.LevelId);
            ViewData["CourseId"] = id;
            ViewData["CourseName"] = course.CourseName;
            ViewData["CoursePrice"] = course.Price;
            ViewData["CourseImage"] = course.Image;
             return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,Price,DepartmentId,Image,Rate,Language,AccountId,Description,IsSale,UpdateAt,LevelId")] Course course)
        {
            if (id != course.CourseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", course.AccountId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "LevelId", course.LevelId);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Account)
                .Include(c => c.Department)
                .Include(c => c.Level)
                .FirstOrDefaultAsync(m => m.CourseId == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CourseId"] = course.CourseId;
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Course course = await _context.Courses.FirstOrDefaultAsync(x=>x.CourseId==id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }
    }
}
