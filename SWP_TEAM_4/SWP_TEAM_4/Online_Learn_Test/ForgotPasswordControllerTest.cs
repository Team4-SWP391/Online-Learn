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
    internal class ForgotPasswordControllerTest
    {
        protected Online_LearnContext context;
        protected ForgotPasswordController forgotPasswordController;

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
        public void TestSendMail(string email)
        {
            forgotPasswordController = new ForgotPasswordController(context);
            var result = forgotPasswordController.SendMail(email);
            Assert.AreEqual("True", result.ToString());

        }
        private static readonly object[] TestCases =
        {
            new object[]{"tuan@gmail.com"},
            new object[]{"a"},
            new object[]{"admin@gmail.com"},
            new object[]{"test1@gmail.com"},
            new object[]{"test2@gmail.com"},
            new object[]{"test3@gmail.com"},
            new object[]{"tuannvhe151098@fpt.edu.vn"},
            new object[]{"admin"},
            new object[]{"tuan"},
            new object[]{"13345"},
            new object[]{"aaa"},
            new object[]{"khach@gmail.com"},
            new object[]{"vinh@gmail.com"},


        };
   }
}
