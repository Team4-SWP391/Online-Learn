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

namespace Online_Learn.Controllers
{
    public class CartController : Controller
    {
        private readonly Online_LearnContext _context;

        public CartController(Online_LearnContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> ViewCart()
        {
            var cart = JsonSerializer.Deserialize<List<Course>>(HttpContext.Session.GetString("cart"));
            var list1 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(4).ToListAsync();
            var list2 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(4).ToListAsync();
            var list3 = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(4).ToListAsync();
            var course_rcm = await _context.Courses.Include(x => x.Account).Include(x => x.Department).Include(x => x.Level).OrderBy(x => Guid.NewGuid()).Take(1).FirstOrDefaultAsync();
            double price = 0;
            foreach (var item in cart)
            {
                price += item.Price;
            }
            ViewBag.course_rcm = course_rcm;
            ViewBag.list1 = list1;
            ViewBag.list2 = list2;
            ViewBag.list3 = list3;
            ViewBag.cart = cart;
            ViewBag.price = price;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CheckOut()
        {
            var cart = JsonSerializer.Deserialize<List<Course>>(HttpContext.Session.GetString("cart"));
            double price = 0;
            foreach (var item in cart)
            {
                price += item.Price;
            }
            ViewBag.cart = cart;
            ViewBag.price = price;
            return View();
        }


        public bool CourseOwner(AccountCourse ac)
        {
            var acs = _context.AccountCourses.ToList();
            foreach (var item in acs)
            {
                if(item.AccountId == ac.AccountId && item.CourseId == ac.CourseId)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpPost]
        public async Task<IActionResult> CheckOut(double amount)
        {
            var user = JsonSerializer.Deserialize<Account>(HttpContext.Session.GetString("User"));
            Account account = await _context.Accounts.FirstOrDefaultAsync(x => x.AccountId == user.AccountId);
            var cart = JsonSerializer.Deserialize<List<Course>>(HttpContext.Session.GetString("cart"));
            double price = 0;
            foreach (var item in cart)
            {
                price += item.Price;
            }
            if (amount > account.Amount)
            {
                ViewBag.err = "Customer's account does not have enough money to make a transaction";
                ViewBag.price = price;
                ViewBag.cart = cart;
                return View();
            }

            if (cart != null)
            {
                account.Amount = account.Amount - amount;
                user.Amount = user.Amount - amount;
                Order od = new Order();
                od.AccountId = user.AccountId;
                od.TotalPrice = price;
                _context.Orders.Add(od);
                _context.SaveChanges();
                foreach (var item in cart)
                {
                    AccountCourse ac = new AccountCourse();
                    ac.AccountId = user.AccountId;
                    ac.CourseId = item.CourseId;
                    OrderDetail odt = new OrderDetail();
                    odt.CourseId = item.CourseId;
                    odt.OrderId = od.OrderId;
                    odt.Quantity = 1;
                    _context.OrderDetails.Add(odt);
                    if (!CourseOwner(ac))
                    {
                        _context.AccountCourses.Add(ac);
                    }
                }
                _context.SaveChanges();
            }
            HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
            cart.Clear();
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
            return Redirect("/Cart/ThankYou");
        }
        public async Task<IActionResult> ThankYou()
        {
            return View();
        }

        public async Task<IActionResult> Remove(int id)
        {
            var cart = JsonSerializer.Deserialize<List<Course>>(HttpContext.Session.GetString("cart"));
            if (cart != null)
            {
                cart.Remove(cart.Where(x => x.CourseId == id).FirstOrDefault());
            }
            HttpContext.Session.SetString("cart", JsonSerializer.Serialize(cart));
            return Redirect("/Cart/ViewCart");
        }
    }
}
