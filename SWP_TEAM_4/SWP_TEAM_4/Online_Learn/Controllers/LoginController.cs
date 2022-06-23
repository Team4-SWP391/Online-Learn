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
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;

using Newtonsoft.Json;

using Online_Learn.Models;

namespace Online_Learn.Controllers {
    public class LoginController : Controller {
        private readonly Online_LearnContext _context;
        public LoginController(Online_LearnContext context)
        {
            _context = context;
        }

        // GET: Login_Udemy
        public IActionResult Login_Udemy()
        {
            string email = HttpContext.Request.Cookies["email"];
            string pass = HttpContext.Request.Cookies["pass"];
            string remember = HttpContext.Request.Cookies["remember"];
            ViewData["email"] = email;
            ViewData["pass"] = pass;
            ViewData["remember"] = remember == "on" ? "checked" : "";
            return View("Login");
        }

        [HttpPost]
        // POST: Login/Login
        public async Task<IActionResult> Login(string email, string pass, string remember)
        {
            if (ModelState.IsValid)
            {
                pass = pass == null ? "" : pass;
                Account user = await _context.Accounts.FirstOrDefaultAsync(a => a.Email == email && a.Password == GetMD5(pass));
                if (user != null)
                {
                    if (remember != null)
                    {
                        HttpContext.Response.Cookies.Append("email", email);
                        HttpContext.Response.Cookies.Append("pass", pass);
                        HttpContext.Response.Cookies.Append("remember", remember);
                    }
                    else
                    {
                        HttpContext.Response.Cookies.Delete("email");
                        HttpContext.Response.Cookies.Delete("pass");
                        HttpContext.Response.Cookies.Delete("remember");
                    }
                    HttpContext.Session.SetString("User", JsonConvert.SerializeObject(user));
                    return Redirect("/Home");
                }
                else
                {
                    ViewData["ErrMess"] = "Email or Password is invalid";
                    return View("Login");
                }
            }
            return View("Login");
        }
        public IActionResult Login_Google()
        {
            //string redirect = "https://accounts.google.com/o/oauth2/auth?scope=email&" +
            //    "redirect_uri=https://localhost:44393/login-google&response_type=code&" +
            //    "client_id=240096817026-hiacplg3lvqrnku3g6ihm26fv3geog3q.apps.googleusercontent.com&approval_prompt=force";
            return Redirect("Login_Google");
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
