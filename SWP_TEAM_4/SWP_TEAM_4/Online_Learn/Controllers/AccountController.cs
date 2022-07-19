using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Online_Learn.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers {
    public class AccountController : Controller {
        private readonly Online_LearnContext context;

        public AccountController(Online_LearnContext _context)
        {
            context = _context;
        }
        //GET
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            Account user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
            Account account = await context.Accounts.Where(x => x.AccountId == user.AccountId).FirstOrDefaultAsync();
            ViewBag.account = account;
            return View();
        }


        public int ProfileTest(Account NewAccount)
        {
            Account a = context.Accounts.FirstOrDefault(x => x.AccountId == NewAccount.AccountId);
            if (a != null)
            {
                a.AccountId = NewAccount.AccountId;
                a.FulllName = NewAccount.FulllName;
                a.Gender = NewAccount.Gender;
                a.Dob = NewAccount.Dob;
                a.Address = NewAccount.Address;
                a.Phone = NewAccount.Phone;
                a.RoleId = a.RoleId;
                a.Password = a.Password;
                a.Username = a.Username;
                a.Language = NewAccount.Language;
                a.Email = NewAccount.Email;
                a.Image = a.Image;
                a.Desc = a.Desc;
                //a.Amount = NewAccount.Amount;
            }
                if(context.SaveChanges() > 0)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
        }

        [HttpPost]
        public async Task<IActionResult> Profile(Account NewAccount)
        {
            Account a = await context.Accounts.FirstOrDefaultAsync(x => x.AccountId == NewAccount.AccountId);
            if (a != null)
            {
                a.AccountId = NewAccount.AccountId;
                a.FulllName = NewAccount.FulllName;
                a.Gender = NewAccount.Gender;
                a.Dob = NewAccount.Dob;
                a.Address = NewAccount.Address;
                a.Phone = NewAccount.Phone;
                a.RoleId = a.RoleId;
                a.Password = a.Password;
                a.Username = a.Username;
                a.Language = NewAccount.Language;
                a.Email = NewAccount.Email;
                a.Image = a.Image;
                a.Desc = a.Desc;
                //a.Amount = NewAccount.Amount;
                context.SaveChangesAsync();
            }
            return Redirect(nameof(Profile));
        }



        public async Task<IActionResult> UserList(int id,string name_search, int pageIndex)
        {
            

            List<Account> list_user = new List<Account>();
            if (pageIndex <= 0 || pageIndex == null)
            {
                pageIndex = 1;
            }
            int pageSize = 8;
            int checkPage = 0;
            int totalUser = 0;
            if (name_search != null)
            {
                if(id == 1)
                {
                    list_user = await context.Accounts.Where(x=> x.RoleId == 1).Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(r=>r.RoleId == 1).Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).ToList().Count;
                }
                else if (id == 2)
                {
                    list_user = await context.Accounts.Where(x => x.RoleId == 2).Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(r => r.RoleId == 2).Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).ToList().Count;
                }
                else if (id == 3)
                {
                    list_user = await context.Accounts.Where(x => x.RoleId == 3).Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(r => r.RoleId == 3).Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).ToList().Count;
                }
                else
                {
                    list_user = await context.Accounts.Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).
                    Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(x => x.FulllName.ToLower().Contains(name_search.ToLower())).ToList().Count;
                }

               
                
                checkPage = 1;
            }
            else
            {
                if(id == 1)
                {
                    list_user = await context.Accounts.Where(r=>r.RoleId == 1).Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(r=>r.RoleId ==1).ToList().Count;
                }
                else if (id == 2)
                {
                    list_user = await context.Accounts.Where(r => r.RoleId == 2).Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(r => r.RoleId == 2).ToList().Count;
                }
                else if (id == 3)
                {
                    list_user = await context.Accounts.Where(r => r.RoleId == 3).Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.Where(r => r.RoleId == 3).ToList().Count;
                }
                else
                {
                    list_user = await context.Accounts.Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToListAsync();
                    totalUser = context.Accounts.ToList().Count;
                }


                checkPage = 2;
            }

            int maxPage = totalUser / pageSize + (totalUser % pageSize != 0 ? 1 : 0);
            ViewBag.roleid = id;
            ViewBag.list_user = list_user;
            ViewBag.checkPage = checkPage;
            ViewBag.MaxPage = maxPage;
            ViewBag.name_search = name_search;
            ViewBag.pageIndex = pageIndex;
            ViewBag.prevPage = pageIndex - 1;
            ViewBag.nextPage = pageIndex + 1;
            ViewBag.student = 1;
            return View();


        }




        public IActionResult Add()
        {
            return View();
        }

        // POST: Account/Add

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add([Bind("AccountId,Username,Password,FulllName,RoleId,Gender,Dob,Address,Phone,Language,Image,Email,Amount,Desc")] Account account)
        {
            if (ModelState.IsValid)
            {
                context.Add(account);
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(UserList));
            }
            return View(account);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await context.Accounts
                .FirstOrDefaultAsync(m => m.AccountId == id);
            if (account == null)
            {
                return NotFound();
            }
            
            return View(account);
        }




        // GET: Account/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var account = await context.Accounts.FindAsync(id);
            if (account == null)
            {
                return NotFound();
            }

            ViewBag.AccountId = id;
            return View(account);
           


        }

        // POST: Account/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AccountId,Username,Password,FulllName,RoleId,Gender,Dob,Address,Phone,Language,Image,Email,Amount,Desc")] Account account)
        {
           

            if (id != account.AccountId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    context.Update(account);
                    await context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AccountExists(account.AccountId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(UserList));
            }

           ViewBag.role_id = account.RoleId;
            return View(account);
        }


        public async Task<IActionResult> Delete(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var account = await context.Accounts.FindAsync(id);
            context.Accounts.Remove(account);
            await context.SaveChangesAsync();

            if (account == null)
            {
                return NotFound();
            }
          
           
            return RedirectToAction(nameof(UserList));
        }


        private bool AccountExists(int id)
        {
            return context.Accounts.Any(e => e.AccountId == id);
        }
    }
}
