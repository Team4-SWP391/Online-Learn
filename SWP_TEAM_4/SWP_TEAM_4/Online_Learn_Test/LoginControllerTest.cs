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
using Microsoft.Extensions.Options;


using NUnit.Framework;

using Online_Learn.Controllers;
using Online_Learn.Models;

namespace Online_Learn_Test {
    [TestFixture]
    internal class LoginControllerTest {
        public Online_LearnContext context;
        public LoginController loginController;
        private IServiceCollection services;
        dynamic options = null;

        [SetUp]
        public void Setup()
        {

            options = new DbContextOptionsBuilder<Online_LearnContext>()
          .UseInMemoryDatabase(databaseName: "Online_Learn")
          .Options;
            context = new Online_LearnContext(options);
            loginController = new LoginController(context);
            addDB();
        }


        private void addDB()
        {
            List<Account> accounts = new List<Account>
            {
                new Account {
                Email = "admin@gmail.com",
                Password = "202cb962ac59075b964b07152d234b70" },
                new Account {
                Email = "vinhlqhe153037@fpt.edu.vn",
                Password = "202cb962ac59075b964b07152d234b70" },
            };
            context.AddRange(accounts);

            context.SaveChanges();
        }

        [Test]
        [TestCase("admin@gmail.com", "123")]
        [TestCase("admin@gmail.com", null)]
        [TestCase("", "123")]
        [TestCase("123", "123")]
        [TestCase("admin", "admin")]
        [TestCase("admin@gmail.com", "123admin")]
        [TestCase("adminadmin", "123@@@@")]
        [TestCase("vinhlqhe153037@fpt.edu.vn", "123")]
        [TestCase("adminadmin", "******")]
        [TestCase("********", "123@@@@")]

        public async Task TestLogin(string email, string pass)
        {
<<<<<<< HEAD
            loginController = new LoginController(context);
            var result = loginController.GetAccount("hainam123", "123456");
            Assert.AreEqual(result, null);
=======
            var result = loginController.GetAccount(email, pass);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("123")]
        [TestCase("")]
        [TestCase("0asdasd")]
        [TestCase()]
        [TestCase("asdasd")]
        [TestCase(null)]
        public void TestLoginGoogle(string code)
        {
            var result = loginController.GetMD5(code);
            Assert.IsNotNull(result);
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
>>>>>>> be00fa77822a2614637b576cc451dfdf8d277ced
        }
    }

}
