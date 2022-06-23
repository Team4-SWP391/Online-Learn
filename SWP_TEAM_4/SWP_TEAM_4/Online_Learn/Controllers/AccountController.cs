﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online_Learn.Controllers
{
    public class AccountController : Controller
    {
        private readonly Online_LearnContext context;

        public AccountController(Online_LearnContext _context)
        {
            context = _context;
        }
        //GET
        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            Account account = await context.Accounts.Where(x => x.AccountId == 2).FirstOrDefaultAsync();
            ViewBag.account = account;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Profile(Account NewAccount)
        {
            Account a = await context.Accounts.FirstOrDefaultAsync(x => x.AccountId == NewAccount.AccountId);
            if(a != null)
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
    }
}