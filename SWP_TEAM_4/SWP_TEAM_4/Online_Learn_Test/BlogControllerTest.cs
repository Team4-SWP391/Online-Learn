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
            addDB();
        }


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

        public void testSearch()
        {

        }
    }
}
