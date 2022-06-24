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
    public class BlogController : Controller
    {
        private readonly Online_LearnContext _context;

        public BlogController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Blogs
        public async Task<IActionResult> Index()
        {
            var online_LearnContext = _context.Blogs.Include(b => b.Account).Include(b => b.Department);

            return View(online_LearnContext);
           
        }
        public async Task<IActionResult> Myblog(string search,int id, int? page, string currentFilter)
        {
            var online_LearnContext = from b in _context.Blogs 
                                      where b.AccountId == 1
                                      select b;



            //var online_LearnContext = _context.Blogs.Include(b => b.Account).Include(b => b.Department);

            //if (!String.IsNullOrEmpty(search))
            //{
            //    online_LearnContext = _context.Blogs.Where(b => b.Title.Contains(search));
            //}
            //if (search != null)
            //{
            //    page = 1;
            //}else
            //{
            //    search = currentFilter;
            //}
            //ViewBag.CurrentFilter = search;

            //int pageSize = 3;
            //int PageNumber = (page ?? 1);
            //.ToPagedList(PageNumber, pageSize)

            return View(online_LearnContext);

        }

       


        

     

        
        // GET: Blogs/Details/5
        public async Task<IActionResult> Details(int? id, int? depaid, int?acid)
        {
            if (id == null)
            {
                return NotFound();
            }

            

            var blog = await _context.Blogs
                .Include(b => b.Account)
                .Include(b => b.Department)
                .FirstOrDefaultAsync(m => m.BlogId == id);

           //var  relate =  "select* from Blog where department_id = 1 and account_id = 1";
             var related = from b in _context.Blogs 
                           where b.DepartmentId == depaid
                           select b;


            //var course = from b in _context.Blogs  
            //         join d in _context.Departments on b.DepartmentId equals d.DepartmentId
            //         join c in _context.Courses on d.DepartmentId = c. where b.department_id = 1";



            if (blog == null)
            {
                return NotFound();
            }
            ViewData["BlogId"] = blog.BlogId;
            ViewData["AccountName"] = blog.Account.Username;
            ViewData["AccountImg"] = blog.Account.Image;
            ViewData["user"] = blog.Account.FulllName;

            return View(blog);
            
        }

        // GET: Blogs/Create
        public IActionResult Create()
        {
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password");
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName");
            return View();
        }

        // POST: Blogs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BlogId,Title,Desc1,Desc2,Desc3,UpdateAt,DepartmentId,Content,AccountId")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                _context.Add(blog);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", blog.AccountId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", blog.DepartmentId);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            if (blog == null)
            {
                return NotFound();
            }

            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", blog.AccountId);
          
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", blog.DepartmentId);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BlogId,Title,Desc1,Desc2,Desc3,UpdateAt,DepartmentId,Content,AccountId")] Blog blog)
        {
            if (id != blog.BlogId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blog);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogExists(blog.BlogId))
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
            ViewData["AccountId"] = new SelectList(_context.Accounts, "AccountId", "Password", blog.AccountId);
            ViewData["DepartmentId"] = new SelectList(_context.Departments, "DepartmentId", "DepartmentName", blog.DepartmentId);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var blog = await _context.Blogs.FindAsync(id);
            _context.Blogs.Remove(blog);
            await _context.SaveChangesAsync();

            
            if (blog == null)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var blog = await _context.Blogs.FindAsync(id);
        //    _context.Blogs.Remove(blog);
        //    await _context.SaveChangesAsync();
            
        //    return RedirectToAction(nameof(Index));
        //}

        private bool BlogExists(int id)
        {
            return _context.Blogs.Any(e => e.BlogId == id);
        }
    }
}
