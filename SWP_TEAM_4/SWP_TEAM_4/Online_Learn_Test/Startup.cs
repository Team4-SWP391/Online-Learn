using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Online_Learn.Models;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Online_Learn_Test {
    internal class Startup {
        private readonly IConfiguration config;

        public Startup(IConfiguration config)
        {
            this.config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<Online_LearnContext>(
                options => options.UseSqlServer(this.config.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Singleton);

            services.AddScoped<Online_LearnContext>(provider => provider.GetService<Online_LearnContext>());
        }
    }
}
