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

namespace Online_Learn.Controllers {
    public class CourseController : Controller {
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
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                totalCourse = _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                 Where(x => x.CourseName.ToLower().Contains(name_search.ToLower())).ToList().Count;
                checkPage = 1;
            }
            else
            {
                list_course = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                   Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
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
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                checkPage = 1;
            }
            else
            {
                list_course = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).
                    Where(x => x.Department.DepartmentId == department_id).
                    Skip(((pageIndex - 1) * pageSize )).Take(pageSize).ToListAsync();
                checkPage = 2;
            }
            int totalCourse = 0;

            if (name_search == null)
            {
                totalCourse = _context.Courses.Where(x => x.Department.DepartmentId == department_id).ToList().Count;
            }
            else if (name_search != null)
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

        public async Task<IActionResult> MyCourse(string name_search, int pageIndex)
        {
            Account user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
            int account_id = user.AccountId;
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
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();


                totalCourse = _context.AccountCourses.Include(x => x.Account).Include(x => x.Course).
                    Where(x => x.Account.AccountId == account_id && x.Course.CourseName.ToLower().Contains(name_search.ToLower().Trim())).ToList().Count;

                checkPage = 1;
            }
            else
            {
                courses = await _context.AccountCourses.Include(x => x.Account).Include(x => x.Course).
                    Where(x => x.Account.AccountId == account_id).
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();

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

        //List Question By Course
        public IActionResult Questions(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Course course = _context.Courses.FirstOrDefault(c => c.CourseId == id);
            ViewData["CourseName"] = course.CourseName;
            ViewData["CourseID"] = id;
            List<Lecture> listLectureByCourse = _context.Lectures.Where(l => l.CourseId == id).ToList();
            //ViewData["ListLecture"] = listLectureByCourse;
            ViewBag.ListLecture = listLectureByCourse;
            dynamic model = new System.Dynamic.ExpandoObject();
            List<QuestionDetail> questionsSlider = (from q in _context.Questions
                                                    join l in _context.Lectures on q.LectureId equals l.LectureId
                                                    join c in _context.Courses on l.CourseId equals c.CourseId
                                                    where c.CourseId == id
                                                    join a in _context.Accounts on c.AccountId equals a.AccountId
                                                    select new QuestionDetail(q.QuestionId, q.Quiz, q.Op1, q.Op2, q.Op3, q.Op4, q.Solution, l.LectureName, c.CourseName, c.CourseId, a.FulllName)).ToList();
             //List<QuestionDetail> questions = questionsSlider.Take(3).ToList();
             model.questionsSlider = questionsSlider.ToList();
            //model.questions = questions.ToList();
            return View(model);
        }

        //Create Question in Course
        public IActionResult CreateQuestion(string CourseID, Question question)
        {
            _context.Questions.Add(question);
            _context.SaveChanges();
            return Redirect($"/Course/Questions/{CourseID}");
        }

        //Delete Question Course
        public IActionResult DeleteQuestion(int id)
        {
            Question question = _context.Questions.FirstOrDefault(q => q.QuestionId == id);
            var result = (from q in _context.Questions where q.QuestionId == id
                            join l in _context.Lectures on q.LectureId equals l.LectureId
                            select l).ToList();
            int courseId = result.FirstOrDefault().CourseId.Value;
            _context.Remove(question);
            _context.SaveChanges();
            return Redirect($"/Course/Questions/{courseId}");
        }

        //Edit Question Course
        [HttpPost]
        public IActionResult EditQuestion(int id, string quiz, string op1, string op2, string op3, string op4, string solution, int totalQuestion)
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
            Lecture lecture = _context.Lectures.FirstOrDefault(l => l.LectureId == question.LectureId);
            Course course = _context.Courses.FirstOrDefault(c => c.CourseId == lecture.CourseId);
            List<QuestionDetail> questionsSlider = (from q in _context.Questions
                                                    join l in _context.Lectures on q.LectureId equals l.LectureId
                                                    join c in _context.Courses on l.CourseId equals c.CourseId
                                                    where c.CourseId == course.CourseId
                                                    join a in _context.Accounts on c.AccountId equals a.AccountId
                                                    select new QuestionDetail(q.QuestionId, q.Quiz, q.Op1, q.Op2, q.Op3, q.Op4, q.Solution, l.LectureName, c.CourseName, c.CourseId, a.Username)).ToList();
            return PartialView("QuestionPartial", questionsSlider);
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

    public class QuestionDetail
    {
        public int QuestionId { get; set; }
        public string Quiz { get; set; }
        public string Op1 { get; set; }
        public string Op2 { get; set; }

        public string Op3 { get; set; }

        public string Op4 { get; set; }

        public string Solution { get; set; }

        public string Lecture { get; set; }

        public string CourseName { get; set; }

        public int CourseID { get; set; }

        public string Author { get; set; }

        public QuestionDetail(int questionId, string quiz, string op1, string op2, string op3, string op4, string solution, string lecture, string courseName, int courseID, string author)
        {
            QuestionId = questionId;
            Quiz = quiz;
            Op1 = op1;
            Op2 = op2;
            Op3 = op3;
            Op4 = op4;
            Solution = solution;
            Lecture = lecture;
            CourseName = courseName;
            CourseID = courseID;
            Author = author;
        }
    }


}
