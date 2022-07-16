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
    internal class CourseControllerTestcs
    {
        protected Online_LearnContext context;
        protected CourseController courseController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<Online_LearnContext>()
            .UseInMemoryDatabase(databaseName: "Online_Learn")
            .Options;
            context = new Online_LearnContext(options);
        }

    //    [Test]
    //    [TestCase("1", "Learn Java", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "2022/01/02", "1")]
    //    [TestCase("1", "C#", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "", "1")]
    //    [TestCase("1", "SQL server", "99", "3", "", "5", "English", "1", "testt", "2", "03/03/2022", "1")]
    //    [TestCase("2", "Java with developvement", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "mo taaaa", "2", "2022/07/01", "1")]
    //    [TestCase("2", "Java, C#, Python", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "", "1", "mo taaaa", "error", "2022/05/05", "1")]
    //    [TestCase("a", "hi", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "2022/01/02", "1")]
    //    [TestCase("3", "haiz", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "co loi", "04/05/22", "1")]


    //    public async Task TestCreateCourse(int CourseId, String CourseName, Double Price, int DepartmentId, String Image, int Rate, String Language, int AccountId, String Description, int IsSale, DateTime UpdateAt, int LevelId)
    //    {
    //        courseController = new CourseController(context);
    //        var resutl = courseController.add(CourseId, CourseName, Price, DepartmentId, Image, Rate, Language, AccountId, Description, IsSale, UpdateAt, LevelId);
    //        Assert.AreEqual(resutl, 1);
    //    }

    //    [Test]
    //    [TestCase("1", "Learn Java", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "", "1")]
    //    [TestCase("1", "Learn Java", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "2022/01/02", "1")]
    //    [TestCase("1", "C#", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "", "1")]
    //    [TestCase("1", "SQL server", "99", "3", "", "5", "English", "1", "testt", "2", "03/03/2022", "1")]
    //    [TestCase("2", "Java with developvement", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "mo taaaa", "2", "2022/07/01", "1")]
    //    [TestCase("2", "Java, C#, Python", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "", "1", "mo taaaa", "error", "2022/05/05", "1")]
    //    [TestCase("a", "hi", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "2022/01/02", "1")]
    //    [TestCase("3", "haiz", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "co loi", "04/05/22", "1")]
    //    [TestCase("1", "Learn Java", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "2022/01/02", "1")]
    //    [TestCase("1", "C#", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "", "1")]
    //    [TestCase("1", "SQL server", "99", "3", "", "5", "English", "1", "testt", "2", "03/03/2022", "1")]
    //    [TestCase("2", "Java with developvement", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "mo taaaa", "2", "2022/07/01", "1")]
    //    [TestCase("2", "Java, C#, Python", "84.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "", "1", "mo taaaa", "error", "2022/05/05", "1")]
    //    [TestCase("a", "hi", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "2", "2022/01/02", "1")]
    //    [TestCase("3", "haiz", "199.99", "2", "https://img-c.udemycdn.com/course/240x135/4259956_25c8_4.jpg", "5", "English", "1", "testt", "co loi", "04/05/22", "1")]

    //    public async Task TestUpdateCourse(int CourseId, String CourseName, Double Price, int DepartmentId, String Image, int Rate, String Language, int AccountId, String Description, int IsSale, DateTime UpdateAt, int LevelId)
    //    {
    //        courseController = new CourseController(context);
    //        var resutl = courseController.update(CourseId, CourseName, Price, DepartmentId, Image, Rate, Language, AccountId, Description, IsSale, UpdateAt, LevelId);
    //        Assert.AreEqual(resutl, 1);
    //    }

    }
}
