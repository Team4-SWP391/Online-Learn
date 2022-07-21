using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Online_Learn.Models;
using Online_Learn.Service;
using static Online_Learn.Service.SendMailService;

namespace Online_Learn.Controllers
{
    public class ForgotPasswordController : Controller
    {
        private readonly Online_LearnContext _context;

        public ForgotPasswordController(Online_LearnContext context)
        {
            _context = context;
        }
        public ActionResult Forgot()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> ConfirmAsync(string email)
        {
            var check = _context.Accounts.FirstOrDefault(a => a.Email == email);
            if (check != null)
            {
                IOptions<MailSetting> _mailSettings = Options.Create(new MailSetting
                {
                    Mail = "Tuannvhe151098@fpt.edu.vn",
                    DisplayName = "OnlineLearning",
                    Password = "tuan@He151098",
                    Host = "smtp.gmail.com",
                    Port = 587
                });
                var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
                var stringChars = new char[30];
                var random = new Random();

                for (int i = 0; i < stringChars.Length; i++)
                {
                    stringChars[i] = chars[random.Next(chars.Length)];
                }
                var token = new String(stringChars);

                string body = $"<p>You must to change your password in <a href=\"https://localhost:44396/changepassword/changepassword?token={token}\"  target=\"_blank\">here<a><p>";
                AccountToken account = new AccountToken();
                DateTime time = DateTime.Now;
                account.Email = email;
                account.Token = token;
                account.CreateToken = time;
                _context.AccountTokens.Add(account);
                _context.SaveChanges();
                SendMailService sendMailService = new SendMailService(_mailSettings);
                await sendMailService.SendEmailAsync(email, "Reset Password", body);
                return View();
            }
            else
            {
                ViewBag.message = "Email isn't exist in system!";
                return View("Forgot");
            }
        }
        public bool SendMail(string email)
        {
            return email.Contains("@");
        }
    }
}
