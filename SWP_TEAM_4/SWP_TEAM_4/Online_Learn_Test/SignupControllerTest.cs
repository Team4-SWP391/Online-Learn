using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using NUnit.Framework;

using Online_Learn.Controllers;
using Online_Learn.Models;

namespace Online_Learn_Test
{
    [TestFixture]
    internal class SignupControllerTest
    {
        protected Online_LearnContext context;
        protected SignupController signupController;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Online_LearnContext>()
            .UseInMemoryDatabase(databaseName: "Online_Learn")
            .Options;
            context = new Online_LearnContext(options);
        }

        [Test]
        [TestCaseSource("TestCases")]
        public void TestHTTPPostSignup(Account account)
        {
            signupController = new SignupController(context);
            var result = (RedirectResult)signupController.Register(account);
            Assert.AreEqual("../Home/Index", result.Url);
        }
        private static readonly object[] TestCases =
 {
       new object[]{new Account(){Username = "Tuan",
                Email = "tuan@gmail.com",
                Password = "tuan123"} },
      new object[]{new Account(){Username = "Tuan",
                Email = "tuan@gmail.com",
                Password = "tuan"} },
      new object[]{new Account(){Username = "T",
                Email = "tuan@gmail.com",
                Password = "tuan123"} },
      new object[]{new Account(){Username = "Tu",
                Email = "tuan@gmail.com",
                Password = "tuan**"} },
      new object[]{new Account(){Username = "",
                Email = "",
                Password = ""} },
      new object[]{new Account(){Username = "Tuan#@",
                Email = "tuan@gmail.com",
                Password = "tuan"} },
      new object[]{new Account(){Username = "Tuan0908",
                Email = "tuan@gmail.com",
                Password = "12@"} },
      new object[]{new Account(){Username = "tuan123",
                Email = "tuan@gmail.com",
                Password = "tuanadsffg34"} },
      new object[]{new Account(){Username = "admin123",
                Email = "tuan@gmail.com",
                Password = "123456"} },
      new object[]{new Account(){Username = "_32asdjg",
                Email = "tuan@gmail.com",
                Password = "1111111"} },
};

        [TestCase]
        public void TestViewDataTitleExist()
        {
            signupController = new SignupController(context);
            var result = signupController.Register() as ViewResult;
            Assert.AreEqual("Register", result.ViewData["Title"]);
        }
    }
}

    


