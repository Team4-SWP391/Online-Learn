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
    internal class CourseControllerTest
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

        [Test]
        [TestCase("react")]
        [TestCase(" View")]
        [TestCase(null)]
        [TestCase("Net   ")]
        [TestCase("")]
        [TestCase("%")]
        [TestCase("1 HOUR")]
        [TestCase("NET")]
        [TestCase("   ")]
        [TestCase(1)]
        public void SearchTest(string search)
        {
            //loginController = new LoginController(context);
            //var result = loginController.GetAccount("hainam123", "123456");
            //Assert.AreEqual(result, null);
            var rs = context.Courses.Where(x=>x.CourseName.ToLower().Contains(search.ToLower())).ToList();
            courseController = new CourseController(context);
            var result = courseController.getAllCourse(search);
            Assert.AreEqual(result, rs);
        }


        [Test]
        [TestCase("React", 1)]
        [TestCase("React", 0)]
        [TestCase("React", 1.4)]
        [TestCase(null, 2)]
        [TestCase("React", "*")]
        [TestCase("     ", 1)]
        [TestCase("React", null)]
        [TestCase("", 1)]
        [TestCase("*", 1)]
        [TestCase("  ", 1)]
        [TestCase(null, null)]
        [TestCase(1.5, 2.7)]
        [TestCase(1)]
        [TestCase("react")]
        [TestCase("react", -1)]
        public void TestCourseListByDepartment(string search, int department)
        {
            var rs = context.Courses.Where(x => x.CourseName.Contains(search) && x.DepartmentId == department).ToList();
            courseController = new CourseController(context);
            var result = courseController.getAllCourseByDepartment(search, department);
            Assert.AreEqual(result, rs);
        }


        [Test]
        [TestCase(1,9)]
        [TestCase("*",9)]
        [TestCase(null,null)]
        [TestCase("a","x")]
        [TestCase("","")]
        [TestCase("    ","")]
        [TestCase("asd asd",9)]
        [TestCase("","sadds")]
        [TestCase(1.5,9)] 
        [TestCase(1)]
        [TestCase(3.6, 6.7)]
        [TestCase("")]
        [TestCase(null, -1)]
        [TestCase("9","")]
        [TestCase("React",null)]
        public void PaggingTest(int pageIndex, int pageSize)
        {
            var rs = context.Courses.Skip(((pageIndex - 1) * pageSize)).Take(pageSize).ToList();
            courseController = new CourseController(context);
            List<Course> result = courseController.Pagging(pageIndex, pageSize);
            Assert.AreEqual(result, rs);
        }
    }
}
