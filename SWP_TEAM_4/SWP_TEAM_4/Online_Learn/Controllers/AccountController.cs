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



        public async Task<IActionResult> UserList()
        {

            var customer = context.Accounts.Where(a=> a.RoleId == 1).ToList();
            var user = context.Accounts.ToList();
            ViewBag.user = user;

            return View(await context.Accounts.ToListAsync());
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
