using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

//using Newtonsoft.Json;
using System.Text.Json;
using Online_Learn.AuthData;
using Online_Learn.Models;
using Newtonsoft.Json;

namespace Online_Learn.Controllers {
    public class HomeController : Controller {
        private readonly ILogger<HomeController> _logger;
        private readonly Online_LearnContext _context;

        public HomeController(ILogger<HomeController> logger, Online_LearnContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            Random rand = new Random();
            var list1 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list2 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list3 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list4 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list5 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list6 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list7 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list8 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var list9 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(10).ToListAsync();
            var course_rcm = list1.OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefault();
            ViewBag.list1 = list1;
            ViewBag.list2 = list2;
            ViewBag.list3 = list3;
            ViewBag.list4 = list4;
            ViewBag.list5 = list5;
            ViewBag.list6 = list6;
            ViewBag.list7 = list7;
            ViewBag.list8 = list8;
            ViewBag.list9 = list9;
            ViewBag.course_rcm = course_rcm.CourseName;
            return View();
        }
        // Get: /Home/Search
        public IActionResult Search(string txtSearch)
        {
            var list = _context.Courses.Include(c => c.Account)
                .Include(c => c.Level).Where(x => x.CourseName.Contains(txtSearch)).ToList();
            ViewData["txtSearch"] = txtSearch;
            ViewBag.listTopic = _context.Departments.ToList();
            ViewBag.listLevel = _context.Levels.ToList();
            return View("~/Views/Course/Search.cshtml", list);
        }

        public IActionResult AdvanceSearch(string txtSearch, int valueSearch, string type)
        {
            List<Course> list = _context.Courses.Include(c => c.Account).Include(c => c.Level).Where(x => x.CourseName.Contains(txtSearch)).ToList();
            switch (type)
            {
                case "Department":
                    list = list.Where(c => c.DepartmentId == valueSearch).ToList();
                    break;
                case "Level":
                    list = list.Where(c => c.LevelId == valueSearch).ToList();
                    break;
                case "Rate":
                    list = list.Where(c => c.Rate >= valueSearch).ToList();
                    break;
                case "Price":
                    list = list.Where(c => c.Price >= valueSearch).ToList();
                    break;
                default:
                    break;
            }
            return PartialView("~/Views/Course/SearchPartial.cshtml", list);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
