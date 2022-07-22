using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using Online_Learn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JsonSerializer = System.Text.Json.JsonSerializer;
using Online_Learn.AuthData;
using Microsoft.AspNetCore.Authorization;

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
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
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

        public List<Course> getAllCourse(string name_search)
        {
            var list_course = _context.Courses.
                Include(x => x.Account).Include(x => x.Level).Include(x => x.Department).
                Where(x => x.CourseName.ToLower().Contains(name_search.ToLower())).ToList();
            return list_course;
        }


        public List<Course> getAllCourseByDepartment(string name_search, int department)
        {
            var list_course = _context.Courses.
                Include(x => x.Account).Include(x => x.Level).Include(x => x.Department).
                Where(x => x.CourseName.Contains(name_search) && x.DepartmentId == department).ToList();
            return list_course;
        }


        public List<Course> Pagging(int pageIndex, int pageSize)
        {
            int size = pageSize;
            int page = pageIndex;
            var list_course = _context.Courses.ToList();
            int totalCourse = list_course.Count;
            int maxPage = totalCourse / pageSize + (totalCourse % pageSize != 0 ? 1 : 0);
            List<Course> list = _context.Courses.Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            return list;
        }

        public async Task<IActionResult> MyCourse(string name_search, int pageIndex)
        {
            Account user = JsonSerializer.Deserialize<Account>(HttpContext.Session.GetString("User"));
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

            int owner = 0;
            Account account = HttpContext.Session.GetString("User") != null ? JsonSerializer.Deserialize<Account>(HttpContext.Session.GetString("User")) : null;
            if (account != null)
            {
                AccountCourse ac = _context.AccountCourses.FirstOrDefault(x => x.AccountId == account.AccountId && x.CourseId == id);
                if (ac != null)
                {
                    owner = 1;
                }
            }

            var lectures = _context.Lectures.Where(x => x.CourseId == id).ToList();

            ViewBag.lectures = lectures;

            dynamic model = new System.Dynamic.ExpandoObject();
            var listLecture = _context.Lectures.Where(l => l.CourseId == id).ToList();
            var listLectureId = listLecture.Select(l => l.LectureId).ToList();
            var listLesson = _context.Lessons.Where(l => listLectureId.Contains((int)l.LectureId)).ToList();
            model.listLecture = listLecture;
            model.listLesson = listLesson;
            model.course = course;
            ViewBag.owner = owner;
            return View(model);
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

        [Authorize(Roles = "admin")]
        [Authorize(Roles = "author")]
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
            var lectures = _context.Lectures.Where(x => x.CourseId == id).ToList();
            var exam = (from e in _context.Exams
                        join l in _context.Lectures on e.LectureId equals l.LectureId
                        join c in _context.Courses on l.CourseId equals c.CourseId
                        where l.CourseId == id
                        select e).ToList();
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", course.AccountId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", course.DepartmentId);
            ViewData["LevelId"] = new SelectList(_context.Levels, "LevelId", "LevelId", course.LevelId);
            ViewData["CourseId"] = id;
            ViewData["CourseName"] = course.CourseName;
            ViewData["CoursePrice"] = course.Price;
            ViewData["CourseImage"] = course.Image;
            ViewBag.lectures = lectures;
            ViewBag.exam = exam;
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
            var result = (from q in _context.Questions
                          where q.QuestionId == id
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
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "author")]

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
        [Authorize(Roles = "admin")]
        [Authorize(Roles = "author")]

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

        public async Task<IActionResult> addLecture(Lecture NewLecture)
        {
            _context.Lectures.Add(NewLecture);
            _context.SaveChangesAsync();
            return Redirect($"Edit?id={NewLecture.CourseId}");
        }


        public bool checkCourseExist(List<Course> list, Course course)
        {
            bool check = false;
            foreach (var item in list)
            {
                if (item.CourseId == course.CourseId)
                {
                    check = true;
                }
            }
            return check;
        }


        public IActionResult AddToCart(int id)
        {
            string gh = HttpContext.Session.GetString("cart");
            Course c = _context.Courses.FirstOrDefault(x => x.CourseId == id);
            List<Course> cart = new List<Course>();
            if (gh != null)
            {
                cart = JsonSerializer.Deserialize<List<Course>>(gh);
                if (!checkCourseExist(cart, c))
                {
                    cart.Add(c);
                }
            }
            else
            {
                if (!checkCourseExist(cart, c))
                {
                    cart.Add(c);
                }
            }
            double price = 0;
            foreach (var item in cart)
            {
                price += item.Price;
            }
            HttpContext.Session.SetString("cart", JsonConvert.SerializeObject(cart));
            HttpContext.Session.SetString("TotalPrice", price.ToString());
            return Redirect($"/Course/Details?id={id}");
        }


        public bool checkWLExist(WhistList w)
        {
            bool check = false;
            var wls = _context.WhistLists.ToList();
            foreach (var item in wls)
            {
                if (item.AccountId == w.AccountId && item.CourseId == w.CourseId)
                {
                    check = true;
                }
            }
            return check;
        }


        public async Task<IActionResult> AddToWL(int id)
        {
            var account_id = JsonSerializer.Deserialize<Account>(HttpContext.Session.GetString("User")).AccountId;
            WhistList w = new WhistList();
            w.AccountId = account_id;
            w.CourseId = id;
            if (!checkWLExist(w))
            {
                _context.WhistLists.Add(w);
            }
            _context.SaveChanges();
            return Redirect($"/Course/Details?id={id}");
        }


        // GET: Course/VideoPage/5
        public IActionResult Learn(int id)
        {
            Account user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
            dynamic model = new System.Dynamic.ExpandoObject();
            var listLecture = _context.Lectures.Where(l => l.CourseId == id).ToList();
            var listLectureId = listLecture.Select(l => l.LectureId).ToList();
            var listLesson = _context.Lessons.Where(l => listLectureId.Contains((int)l.LectureId)).ToList();

            Course course = _context.Courses.Include(c => c.Level).FirstOrDefault(c => c.CourseId == id);
            ViewBag.course = course;
            model.listLecture = listLecture;
            model.listLesson = listLesson;
            HttpContext.Session.SetString("courseId", id.ToString());
            ViewBag.listLessonsOfAccount = _context.AccountLessons.Where(al => al.AccountId == user.AccountId && al.CourseId == id)
                .Select(al => al.LessonId).ToList();
            ViewBag.listExam = _context.Exams.Where(e => listLectureId.Contains(e.LectureId)).ToList();
            return View("VideoPage", model);
        }


        public IActionResult Progress(int lessonId, int accountId, int courseId)
        {
            AccountLesson accountLesson = _context.AccountLessons.FirstOrDefault(x => x.AccountId == accountId && x.LessonId == lessonId && x.CourseId == courseId);
            if (accountLesson == null)
            {
                _context.AccountLessons.Add(new AccountLesson() { AccountId = accountId, LessonId = lessonId, CourseId = courseId });
                _context.SaveChanges();
                return Json(new { status = "Insert Success" });
            }
            return Json(new { status = "Lesson id is exist" });
        }


    }

}

public class QuestionDetail {
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






