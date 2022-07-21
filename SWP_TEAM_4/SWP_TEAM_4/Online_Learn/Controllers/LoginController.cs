using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

//using Google.Apis.Auth.AspNetCore3;
//using Google.Apis.Services;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileSystemGlobbing;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

using Online_Learn.Models;

using Org.BouncyCastle.Asn1.Crmf;

//using RestSharp;

namespace Online_Learn.Controllers {
    public class LoginController : Controller {
        private readonly Online_LearnContext _context;

        public LoginController(Online_LearnContext context)
        {
            _context = context;
        }


        // GET: Login_Udemy
        public IActionResult Login_Udemy(string ReturnUrl)
        {
            string email = HttpContext.Request.Cookies["email"];
            string pass = HttpContext.Request.Cookies["pass"];
            string remember = HttpContext.Request.Cookies["remember"];
            ViewData["email"] = email;
            ViewData["pass"] = pass;
            ViewData["remember"] = remember == "on" ? "checked" : "";
            ViewBag.ReturnUrl = ReturnUrl;
            return View("Login");
        }

        public Account GetAccount(string email, string pass)
        {
            Account user = _context.Accounts.FirstOrDefault(a => a.Email == email && a.Password == GetMD5(pass));
            return user;
        }

        [HttpPost]
        // POST: Login/Login
        public async Task<IActionResult> Login(string email, string pass, string remember, string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                pass = pass == null ? "" : pass;
                Account user = GetAccount(email, pass);
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
                    string role = "";
                    switch (user.RoleId)
                    {
                        case 1:
                            role = "student";
                            break;
                        case 2:
                            role = "author";
                            break;
                        case 3:
                            role = "sale";
                            break;
                        case 4:
                            role = "admin";
                            break;
                    }
                    var claims = new List<Claim>();
                    claims.Add(new Claim(ClaimTypes.Role, role));
                    var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var claimsPrincipal = new ClaimsPrincipal(claimIdentity);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimsPrincipal, new AuthenticationProperties());
                    return ReturnUrl == null ? RedirectToAction("Index", "Home") : Redirect(ReturnUrl);
                }
                else
                {
                    ViewData["ErrMess"] = "Email or Password is invalid";
                    return View("Login");
                }
            }
            return View("Login");
        }
        public async Task<GoogleToken> Login_Google(string code)
        {
            string clientID = "240096817026-bnoup401nmf0bgig9c6evbpb473r6ou2.apps.googleusercontent.com";
            string clientSecret = "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";
            string redirect_uri = "https://localhost:44396/Login/Login_Google";
            string TokenUri = "https://www.googleapis.com/oauth2/v4/token";
            string scope = "https://www.googleapis.com/auth/userinfo.email";
            GoogleToken token = null;
            var postData = new
            {
                code = code,
                client_id = clientID,
                client_secret = clientSecret,
                redirect_uri = redirect_uri,
                grant_type = "authorization_code"
            };
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(postData), Encoding.UTF8, "application/json");
                using (var response = httpClient.PostAsync(TokenUri, content))
                {
                    string responseString = await response.Result.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<GoogleToken>(responseString);
                }
            }

            return token;
        }


        public string Login_Facebook()
        {
            return "1";
        }


        public string GetMD5(string str)
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
