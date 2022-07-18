using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


using NUnit.Framework;

using Online_Learn.Controllers;
using Online_Learn.Models;


namespace Online_Learn_Test
{

    [TestFixture]
    internal class ChangePasswordControllerTest
    {
        protected Online_LearnContext context;
        protected ChangepasswordController changepasswordController;

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
        public void TestChangingPassword(string newpass, string email)
        {
            changepasswordController = new ChangepasswordController(context);
            var result = changepasswordController.CheckChangingNewPasswordSuccess(newpass, email);
            Assert.AreEqual("True", result.ToString());
        }
        private static readonly object[] TestCases =
    {
            new object[]{"123456","tuan@gmail.com"},
            new object[]{"sqddsaf","test@gmail.com"},
            new object[]{"1245asdf6","tuan@gmail.com"},
            new object[]{"asd","tuan@gmail.com"},
            new object[]{"12456","admin@123"},
            new object[]{"djkashfgdjks","tuan@gmail.com"},
            new object[]{"1245asfd6","tuan@gmail.com"},
            new object[]{"as","tuan@gmail.com"},
            new object[]{"1245@#6","tuan@gmail.com"},
            new object[]{"12456","tuan1232"},
            new object[]{"12456",""},
            new object[]{"124ad56","tuan@gmail.com"},
            new object[]{"12456","123"},
            new object[]{"12456fsda","tuan@gmail.com"},
            new object[]{"12456_21","tuan@gmail.com"},
            new object[]{"12456@@","tuan@gmail.com"},
            new object[]{"12456qw","tuan@gmail.com"},
        };
    }
}

