using Microsoft.AspNetCore.Mvc;

using Online_Learn.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers {
    public class StatisticController : Controller {
        private readonly Online_LearnContext _context;

        public StatisticController(Online_LearnContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetBestSellCourses()
        {
            dynamic courses = _context.Courses.Join(_context.OrderDetails, c => c.CourseId, od => od.CourseId, (c, od) => new { c, od })
                .GroupBy(x => new
                {
                    x.c.CourseId,
                    x.c.CourseName,
                    x.c.Price,
                    x.c.DepartmentId,
                    x.c.Image,
                    x.c.Rate,
                    x.c.Language,
                    x.c.AccountId,
                    x.c.Description,
                    x.c.IsSale,
                    x.c.UpdateAt,
                    x.c.LevelId

                }).OrderByDescending(x => x.Sum(y => y.od.Quantity)).Select(x => new
                {
                    x.Key.CourseId,
                    x.Key.CourseName,
                    x.Key.Price,
                    x.Key.DepartmentId,
                    x.Key.Image,
                    x.Key.Rate,
                    x.Key.Language,
                    x.Key.AccountId,
                    x.Key.Description,
                    x.Key.IsSale,
                    x.Key.UpdateAt,
                    x.Key.LevelId,
                    Count = x.Sum(x => x.od.Quantity)
                }).Take(5).ToList();
            return Json(courses);
        }
        public IActionResult GetTopUsers()
        {
            dynamic userList = _context.Orders.Join(_context.Accounts, o => o.AccountId, a => a.AccountId, (o, a) => new { o, a })
                .GroupBy(x => new
                {
                    x.a.AccountId,
                    x.a.Username,
                }).OrderByDescending(x => x.Sum(y => y.o.TotalPrice)).Select(x => new
                {
                    x.Key.AccountId,
                    x.Key.Username,
                    TotalPrice = x.Sum(x => x.o.TotalPrice)
                }).Take(5).ToList();
            return Json(userList);
        }
        public IActionResult GetRevenueMonthly()
        {
            dynamic revenue = (from o in _context.Orders
                               select new
                               {
                                   o.OrderDate.Value.Year,
                                   o.OrderDate.Value.Month,
                                   o.TotalPrice
                               }).GroupBy(x => new
                               {
                                   x.Year,
                                   x.Month
                               }).Select(x => new
                               {
                                   x.Key.Year,
                                   x.Key.Month,
                                   revenueMonth = x.Sum(x => x.TotalPrice)
                               }).ToList();
            return Json(revenue);
        }
    }
}