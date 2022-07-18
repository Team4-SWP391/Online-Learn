using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers
{
    public class OrderController : Controller
    {
        private readonly Online_LearnContext _context;

        public OrderController(Online_LearnContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> List(int pageIndex)
        {   
            if(pageIndex == null)
            {
                pageIndex = 1;
            }
            int pageSize = 10;
            var orders =  _context.Orders.Skip(((pageIndex - 1) * pageSize)).
                Take(pageSize).ToList();
            int totalOrder = orders.Count();
            int maxPage = totalOrder / pageSize + (totalOrder % pageSize != 0 ? 1 : 0);
            ViewBag.maxPage = maxPage;
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.pageIndex = pageIndex;
            ViewBag.orders = orders;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> List(int pageIndex ,string? name, 
            DateTime? start, DateTime? end, double? to, double? from)
        {
            int pageSize = 10;
            if (pageIndex == null)
            {
                pageIndex = 1;
            }

            if (name == null)
            {
                name = "";
            }
            else
            {
                ViewBag.name = name;
            }
            if(start == null)
            {
                start = _context.Orders.Min(x => x.OrderDate);
            }
            else
            {
                ViewBag.start = start;
            }
            if(end == null)
            {
                end = _context.Orders.Max(x => x.OrderDate);

            }
            else
            {
                ViewBag.end = end;

            }
            if (to == null)
            {
                to = _context.Orders.Min(x => x.TotalPrice);
            }
            else
            {
                ViewBag.to = to;
            }
            if(from == null)
            {
                from = _context.Orders.Max(x => x.TotalPrice);
            }
            else
            {
                ViewBag.from = from;

            }


            var orders =  _context.Orders.
                Where(x => x.Account.FulllName.ToLower().Contains(name.ToLower()) && 
                x.OrderDate >= start && x.OrderDate <= end 
                && x.TotalPrice >= to && x.TotalPrice <= from).Skip(((pageIndex - 1) * pageSize)).
                Take(pageSize).ToList();


            int totalOrder = orders.Count();
            int maxPage = totalOrder / pageSize + (totalOrder % pageSize != 0 ? 1 : 0);
            ViewBag.pageIndex = pageIndex;
            ViewBag.maxPage = maxPage;
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.orders = orders;
            return View();
        }
        public async Task<IActionResult> Detail(int id)
        {
            return View();
        }
    }
}
