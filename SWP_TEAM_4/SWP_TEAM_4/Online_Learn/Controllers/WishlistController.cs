using Microsoft.AspNetCore.Mvc;
using Online_Learn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers
{
    public class WishlistController : Controller
    {
        private readonly Online_LearnContext _context;

        public WishlistController(Online_LearnContext context)
        {
            _context = context;
        }

        public IActionResult Wishlist()
        {
            //var account = _context.WhistLists.Where(w => w.AccountId == 21);
            //var wishlist = _context.Courses.Join(account, course => course.CourseId, a => a.AccountId,)
            IEnumerable<Course> wishlist = from c in _context.Courses
                           join a in _context.WhistLists on c.CourseId equals a.CourseId
                           where a.AccountId == 21
                           select c;
            return View(wishlist);
        }
    }
}
