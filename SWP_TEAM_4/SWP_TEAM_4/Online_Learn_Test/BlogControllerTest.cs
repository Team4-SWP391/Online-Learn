using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using NUnit.Framework;

using Online_Learn.Controllers;
using Online_Learn.Models;

namespace Online_Learn_Test {
    [TestFixture]
    internal class BlogControllerTest {
        public Online_LearnContext context;
        public BlogController blogController;
        private IServiceCollection services;
        dynamic options = null;

        [SetUp]
        public void Setup()
        {

            options = new DbContextOptionsBuilder<Online_LearnContext>()
          .UseInMemoryDatabase(databaseName: "Online_Learn")
          .Options;
            context = new Online_LearnContext(options);
            blogController = new BlogController(context);
            //addDB();
        }


        //[Test]
        //[TestCase(2, "What is Windows Form?", 2, "aaa", 3)]
        //[TestCase(3,"Working with React" ,20, "","4")]
        //[TestCase(4, "Modals?", 2, "aaa", 3)]
        //[TestCase(5, "Benefit of Framwork?", 2, "aaa", 3)]
        //[TestCase(2, "Tracsaction?", 2, "aaa", 3)]
        //[TestCase(7, "Algothism and Data Structure?", 2, "aaa", 3)]
        //[TestCase(1, "JSS/HTML?", 2, "aaa", 3)]
        //[TestCase(11, "How to work with Js", 2, "aaa", 3)]
        //[TestCase(12, "Introduction about .net?", 2, "aaa", 3)]
        //[TestCase(13, "HTML?", 2, "aaa", 3)]
        //public async Task TestCreateBlog(int BlogId, string Title, int DepartmentId, string Content, int AccountId)
        //{
        //    blogController = new BlogController(context);
        //    var resutl = blogController.Createbytest(BlogId, Title, DepartmentId, Content, AccountId);
        //    Assert.AreEqual(resutl, 1);
        //}



        //[Test]
        //[TestCase(5, "Benefit of Framwork?", 2, "aaa")]
        //[TestCase(2, "Tracsaction?", 2, "aaa")]
        //[TestCase(7, "Algothism and Data Structure?", 2, "aaa")]
        //[TestCase(1, "Introduction about React Native", 2, "aaa")]
        //[TestCase(3, "Using Entity Framwork to..", 2, "bb")]
        //[TestCase(4, "Manage time to do..", 2, "aaa")]
        //[TestCase(5, "How to connect with Sql", 2, "bb")]
        //[TestCase(6, "Working on group in Git", 2, "aaa")]
        //[TestCase(7, "Become master excel", 2, "bb")]
        //[TestCase(8, "How to work with Angular", 2, "aaa")]


        //public async Task DetailTest(int BlogId, string Title, int DepartmentId, string Content)
        //{
        //    blogController = new BlogController(context);
        //    var resutl = blogController.DetailTest(BlogId, Title, DepartmentId, Content);
        //    Assert.AreEqual(resutl, 1);
        //}
      

        private void addDB()
        {
            List<Blog> blogs = new List<Blog>
                {
                    new Blog {
                    Title = "react with ss",
                    Content = "reacttttttttt"
                    },
                    new Blog {
                    Title = "AAAAAAAAa with ss",
                    Content = "reacttttttttt"
                    },
                    new Blog {
                    Title = "BBBBBBb with ss",
                    Content = "reacttttttttt"
                    },
                    new Blog {
                    Title = "CCCCCCC with ss",
                    Content = "reacttttttttt"
                    },
                    new Blog {
                    Title = "wwwww with ss",
                    Content = "reacttttttttt"
                    },
                    new Blog {
                    Title = "kkkkk with ss",
                    Content = "reacttttttttt"

                    },


                };
            context.AddRange(blogs);

            context.SaveChanges();
        }

        //    public void testSearch()
        //    {

        //    }
    }
}
