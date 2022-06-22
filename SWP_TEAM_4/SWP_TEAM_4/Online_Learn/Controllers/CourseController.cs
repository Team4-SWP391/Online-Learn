using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers
{
    public class CourseController : Controller 
    {
        private readonly Online_LearnContext _context;

        public CourseController(Online_LearnContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> List(string name_search, int pageIndex)
        {
            List<Course> list_course = new List<Course>();
            if (pageIndex <= 0 || pageIndex == null)
            {
                pageIndex = 1;
            }
            int pageSize = 10;
            int checkPage = 0;
            int totalCourse = 0;
            if (name_search != null)
            {
                list_course = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                    Where(x => x.CourseName.ToLower().Contains(name_search.ToLower())).
                    Skip(((pageIndex - 1) * pageSize + 1)).Take(pageSize).ToListAsync();
                totalCourse = _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                 Where(x => x.CourseName.ToLower().Contains(name_search.ToLower())).ToList().Count;
                checkPage = 1;
            }
            else
            {
                list_course = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                   Skip(((pageIndex - 1) * pageSize + 1)).Take(pageSize).ToListAsync();
                totalCourse = _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).ToList().Count;
                checkPage = 2;
            }

            int maxPage = totalCourse / pageSize + (totalCourse % pageSize != 0 ? 1 : 0);
            List<Department> list_department = await _context.Departments.ToListAsync();
            ViewBag.Departments = list_department;
            ViewBag.list_course = list_course;
            ViewBag.checkPage = checkPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.name_search = name_search;
            ViewBag.pageIndex = pageIndex;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.nextPage = pageIndex + 1;
            return View();
        }

        public async Task<IActionResult> Category(int department_id, string name_search, int pageIndex)
        {
            List<Course> list_course = new List<Course>();
            if (pageIndex <= 0 || pageIndex == null)
            {
                pageIndex = 1;
            }
            int pageSize = 5;
            int checkPage = 0;
            if (name_search != null)
            {
                list_course = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                    Where(x => x.Department.DepartmentId == department_id && x.CourseName.ToLower().Contains(name_search.ToLower())).
                    Skip(((pageIndex - 1) * pageSize + 1) - 1).Take(pageSize).ToListAsync();
                checkPage = 1;
            }
            else
            {
                list_course = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                    Where(x => x.Department.DepartmentId == department_id).
                    Skip(((pageIndex - 1) * pageSize + 1) - 1).Take(pageSize).ToListAsync();
                checkPage = 2;
            }
            int totalCourse = 0;

            if (name_search == null)
            {
                totalCourse = _context.Courses.Where(x => x.Department.DepartmentId == department_id).ToList().Count;
            }
            else if(name_search != null)
            {
                totalCourse = _context.Courses.Where(x => x.Department.DepartmentId == department_id && x.CourseName.ToLower().Contains(name_search.ToLower())).ToList().Count;
            }

            int maxPage = totalCourse / pageSize + (totalCourse % pageSize != 0 ? 1 : 0);

            List<Department> list_department = _context.Departments.ToList();
            ViewBag.Departments = list_department;
            ViewBag.department_id = department_id;
            ViewBag.list_course = list_course;
            ViewBag.checkPage = checkPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.name_search = name_search;
            ViewBag.pageIndex = pageIndex;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.nextPage = pageIndex + 1;
            return View();
        }

        public async Task<IActionResult> MyCourse(int account_id, string name_search, int pageIndex)
        {
            account_id = 4;
            List<AccountCourse> courses = new List<AccountCourse>();
            if (pageIndex <= 0 || pageIndex == null)
            {
                pageIndex = 1;
            }
            int pageSize = 8;
            int checkPage = 0;
            int totalCourse = 0;
            if (name_search != null)
            { 
                courses = await _context.AccountCourses.Include(x => x.Account).Include(x => x.Course).
                    Where(x => x.Account.AccountId == account_id && x.Course.CourseName.ToLower().Contains(name_search.ToLower().Trim())).
                    Skip(((pageIndex - 1) * pageSize + 1)).Take(pageSize).ToListAsync();
                

                totalCourse = _context.AccountCourses.Include(x => x.Account).Include(x => x.Course).
                    Where(x => x.Account.AccountId == account_id && x.Course.CourseName.ToLower().Contains(name_search.ToLower().Trim())).ToList().Count;
                
                checkPage = 1;
            }
            else
            {
                courses = await _context.AccountCourses.Include(x => x.Account).Include(x => x.Course).
                    Where(x => x.Account.AccountId == account_id).
                    Skip(((pageIndex - 1) * pageSize + 1)).Take(pageSize).ToListAsync();

                totalCourse = _context.AccountCourses.Include(x => x.Account).Include(x => x.Course).
                   Where(x => x.Account.AccountId == account_id).ToList().Count;

                checkPage = 2;
            }

            int maxPage = totalCourse / pageSize + (totalCourse % pageSize != 0 ? 1 : 0);
            ViewBag.MyCourse = courses;
            ViewBag.checkPage = checkPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.name_search = name_search;
            ViewBag.pageIndex = pageIndex;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.nextPage = pageIndex + 1;
            return View();
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
                return RedirectToAction(nameof(List));
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
        public async Task<IActionResult> Edit(int id, [Bind("CourseId,CourseName,Price,DepartmentId,Image,Rate,Language,AccountId,Description,IsSale,UpdateAt,LevelId")] Course course)
        {
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
                return RedirectToAction(nameof(List));
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
            Course course = await _context.Courses.FirstOrDefaultAsync(x => x.CourseId == id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(List));
        }

        private bool CourseExists(int id)
        {
            return _context.Courses.Any(e => e.CourseId == id);
        }

    }


}
