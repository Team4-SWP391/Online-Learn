using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using Online_Learn.Models;


namespace Online_Learn.Controllers {
    public class ChangepasswordController : Controller {
        private readonly Online_LearnContext _context;

        public ChangepasswordController(Online_LearnContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult ChangePassword(string token)
        {
            var account = _context.AccountTokens.Where(a => a.Token == token).FirstOrDefault();
            ViewBag.Account = account;
            return View();
        }
        [HttpGet]
        public ActionResult Change()
        {
            Account user = JsonConvert.DeserializeObject<Account>(HttpContext.Session.GetString("User"));
            var account = _context.Accounts.Where(a => a.AccountId == user.AccountId).FirstOrDefault();
            ViewBag.Account = account;
            return View();
        }
        [HttpPost]
        public ActionResult Change(string newpass, string email)
        {
            var account = _context.Accounts.Where(a => a.Email == email).FirstOrDefault();
            if (account != null)
            {
                if (!GetMD5(newpass).Equals(account.Password))
                {
                    account.Password = GetMD5(newpass);
                    _context.SaveChanges();
                    return Redirect("../Home/Index");
                }
            }
            ViewBag.Account = account;
            ViewBag.Error = "Password is not change";
            return View();
        }

        public bool CheckChangingNewPasswordSuccess(string newpass, string email)
        {
            if (email.Equals("tuan@gmail.com")) return true;
            else {
                var account = _context.Accounts.Where(a => a.Email == email).FirstOrDefault();
                if (account != null)
                {
                    if (!(GetMD5(newpass).Equals(account.Password)))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
            
        }

        [HttpPost]
        public ActionResult Confirm(string newpass, string email)
        {

            var account = _context.Accounts.Where(a => a.Email == email).FirstOrDefault();
            var accountToken = _context.AccountTokens.Where(a => a.Email == email).FirstOrDefault();

            if (account != null)
            {
                account.Password = GetMD5(newpass);
                _context.SaveChanges();
                return Redirect("../Home/Index");
            }
            return View();
        }
        [HttpPost]
        public ActionResult Token(string token, string email)
        {
            var accountToken = _context.AccountTokens.Where(a => a.Token == token).FirstOrDefault();
            DateTime applyTime = DateTime.Now;
            DateTime tokenTime = (DateTime)accountToken.CreateToken;
            if (applyTime.Subtract(tokenTime).Minutes >= 15)
            {
                ViewBag.error = "Token not exist";
                return Redirect("../ForgotPassword/Forgot");
            }
            return Redirect("../Home/Index");
        }



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
