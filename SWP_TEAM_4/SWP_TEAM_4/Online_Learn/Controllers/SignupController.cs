using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Online_Learn.Models;

namespace Online_Learn.Controllers
{
    public class SignupController : Controller
    {
        private readonly Online_LearnContext _context;

        public SignupController(Online_LearnContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(AccountSignup accountsignup)
        {
            if (ModelState.IsValid)
            {
                var check = _context.Accounts.FirstOrDefault(a => a.Email == accountsignup.Email);
                if (check == null)
                {
                    Account account = new Account();
                    account.Password = GetMD5(accountsignup.Password);
                    account.Username = accountsignup.Username;
                    account.Email = accountsignup.Email;
                    _context.Accounts.Add(account);
                    _context.SaveChanges();
                    return Redirect("../Login/Login_Udemy");
                }
                else
                {
                    ViewBag.error = "Email is exist!";
                    return View();

                }
            }
            return View();
        }


        //create a string MD5
        public static string GetMD5(string str)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] fromData = Encoding.UTF8.GetBytes(str);
            byte[] targetData = md5.ComputeHash(fromData);
            string byte2String = null;

            for (int i = 0; i < targetData.Length; i++)
            {
                byte2String += targetData[i].ToString("x2");

            }
            return byte2String;
        }

    }
}
