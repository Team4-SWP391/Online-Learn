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
        [TestCase]
        public void TestHTTPPostSignup1()
        {
            Account account = new Account() {
                Username = "Tuan",
                Email = "tuan@gmail.com",
                Password = "tuan123"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }

        [TestCase]
        public void TestHTTPPostSignup2()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "test1@gmail.com",
                Password = "123456"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup3()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "test2@gmail.com",
                Password = "123456"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup4()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "test3@gmail.com",
                Password = "123456"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup5()
        {
            Account account = new Account()
            {
                Username = "",
                Email = "test1@gmail.com",
                Password = "123456"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup6()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "tesfds",
                Password = "123456"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup7()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "test1@gmail.com",
                Password = "123"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup8()
        {
            Account account = new Account()
            {
                Username = "Tuan@@",
                Email = "test1@gmail.com",
                Password = "123456"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup9()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "test1@gmail.com",
                Password = "123456@@"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        [TestCase]
        public void TestHTTPPostSignup10()
        {
            Account account = new Account()
            {
                Username = "Tuan",
                Email = "test1@gmail.com",
                Password = "1234561235342566768642352345325"
            };
            signupController = new SignupController(context);
            var result = signupController.Register(account) as RedirectResult;
            Assert.AreEqual("../Home/Index", result.Url);
        }
        
    }
}





