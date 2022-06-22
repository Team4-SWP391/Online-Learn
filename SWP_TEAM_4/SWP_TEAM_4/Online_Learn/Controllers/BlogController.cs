using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Online_Learn.AuthData;
using Online_Learn.Models;

namespace Online_Learn.Controllers {
    public class BlogController : Controller {
        private readonly Online_LearnContext _context;

        public BlogController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Blog
        public async Task<IActionResult> Index(int pageIndex, string title)
        {
            List<Blog> ListBlog = new List<Blog>();
            int pageNumber = 0;
            if (pageIndex == 0)
            {
                pageIndex = 1;
            }
            int pageSize = 3;

            if (title != null)
            {
                ListBlog = await _context.Blogs.Include(b => b.Account).Include(b => b.Department)
                    .Where(b => b.Title.Contains(title)).Skip((pageIndex - 1) * pageSize + 1).Take(pageSize).ToListAsync();
                pageNumber = Convert.ToInt32(Math.Ceiling((decimal)_context.Blogs
                    .Where(b => b.Title.Contains(title)).ToList().Count / pageSize));
            }
            else
            {
                ListBlog = await _context.Blogs.Include(b => b.Account).Include(b => b.Department)
                .Skip((pageIndex - 1) * pageSize + 1).Take(pageSize).ToListAsync();
                pageNumber = Convert.ToInt32(Math.Ceiling((decimal)_context.Blogs.ToList().Count / pageSize));
            }
            ViewBag.PageNumber = pageNumber;
            int start = pageSize * (pageNumber - 1);
            int end = pageSize * (pageNumber);
            ViewData["pageIndex"] = pageIndex;
            ViewData["pageNumber"] = pageNumber;
            ViewData["title"] = title;
            return View(ListBlog);
        }

        // GET: Blog/MyBlog
        [AuthAttribute]
        public async Task<IActionResult> MyBlog(string title)
        {
            dynamic model = new System.Dynamic.ExpandoObject();
            List<Blog> list = new List<Blog>();
            List<Blog> listWeek = new List<Blog>();
            List<Blog> listMonth = new List<Blog>();
            List<Blog> listYear = new List<Blog>();
            DateTime today = DateTime.Today;
            Account user = HttpContext.Session.GetString("User") != null ?
    JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User")) : null;
            int accountId = user.AccountId;
            title = title == null ? "" : title;
            list = await _context.Blogs.Include(b => b.Account).Include(b => b.Department)
                .Where(b => b.Account.AccountId == accountId && b.Title.Contains(title)).ToListAsync();

            foreach (var item in list)
            {
                int rangeDate = Convert.ToInt32(today.Subtract(Convert.ToDateTime(item.UpdateAt)).Days);
                if (rangeDate <= 7)
                {
                    listWeek.Add(item);
                }
                else if (rangeDate <= 30 && rangeDate > 8)
                {
                    listMonth.Add(item);
                }
                else
                {
                    listYear.Add(item);
                }
            }
            model.listWeek = listWeek;
            model.listMonth = listMonth;
            model.listYear = listYear;
            return View(model);
        }
    }
}
