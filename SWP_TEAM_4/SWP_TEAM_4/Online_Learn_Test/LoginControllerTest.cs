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

namespace Online_Learn_Test {
    [TestFixture]
    internal class LoginControllerTest {
        protected Online_LearnContext context;
        protected LoginController loginController;


        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Online_LearnContext>()
            .UseInMemoryDatabase(databaseName: "Online_Learn")
            .Options;
            context = new Online_LearnContext(options);
        }


        [Test]
        public void TestLogin()
        {
            loginController = new LoginController(context);
            var result = loginController.GetAccount("hainam123", "123456");
            Assert.AreEqual(result, null);
        }
    }
}
