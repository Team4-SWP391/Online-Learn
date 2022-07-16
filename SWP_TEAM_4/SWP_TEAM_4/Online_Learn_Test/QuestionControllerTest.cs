using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using Online_Learn.Controllers;
using Online_Learn.Models;

namespace Online_Learn_Test {
    internal class QuestionControllerTest {

        public Online_LearnContext context;
        public QuestionController QuestionController;
        private IServiceCollection services;
        dynamic options = null;

        [SetUp]
        public void Setup()
        {

            options = new DbContextOptionsBuilder<Online_LearnContext>()
          .UseInMemoryDatabase(databaseName: "Online_Learn")
          .Options;
            context = new Online_LearnContext(options);
            QuestionController = new QuestionController(context);
        }

        [Test]
        [TestCase(null, "React is", "1", "2", "3", "4", "2")]
        [TestCase(2, "Test Question", "1", "2", "3", "4", "2")]
        [TestCase(3, "Edit", "1", "2", "3", "4", "2")]
        [TestCase(4, "Update", "1", "2", "3", "4", "2")]
        [TestCase(4, "Delete", "1", "2", "3", "4", "2")]
        [TestCase(1, "Controller", "1", "2", "3", "4", "2")]
        [TestCase(1, "Models", "1", "2", "3", "4", "2")]
        [TestCase(1, "Remove", "1", "2", "3", "4", "2")]
        [TestCase(1, "JS", "1", "2", "3", "4", "2")]
        [TestCase(1, "Java", "1", "2", "3", "4", "2")]
        public void TestEdit(int id, string quiz, string op1, string op2, string op3, string op4, string solution)
        {
            var result = QuestionController.EditQuestionTest(id, quiz, op1, op2, op3, op4, solution);
            Assert.IsNotNull(result);
        }

        [Test]
        [TestCase("Delete")]
        [TestCase(" ")]
        [TestCase("null")]
        [TestCase(null)]
        [TestCase(1)]
        [TestCase("@ads")]
        public void TestReadExcel(string file)
        {
            var result = QuestionController.ReadExcel(file);
            Assert.IsNotNull(result);
        }

    }
}
