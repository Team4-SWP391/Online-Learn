using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Online_Learn.Models;
using Online_Learn.Service;
using static Online_Learn.Service.SendMailService;

namespace Online_Learn
{
    public class Startup
    {
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public Startup()
        {
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddOptions();
            var mailsetting = Configuration.GetSection("MailSettings");
            services.Configure<MailSetting>(mailsetting);
            services.AddTransient<SendMailService>();
            services.AddAuthentication();
            services.AddMvc();
            services.Configure<DataProtectionTokenProviderOptions>(opt =>
        opt.TokenLifespan = TimeSpan.FromHours(2));
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Online_LearnContext>(options => options.UseSqlServer(connection));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/Confirm", async (context) =>
                {
                    var sendEmail = context.RequestServices.GetService<SendMailService>();
                    //var mailContent = MessageContent();
                    //string kq = await sendEmail.SendMail(mailContent);
                    //await context.Response.WriteAsync(kq);
                });
            });
        }

        public MailContent MessageContent(string to, string subject, string body)
        {
            MailContent mailContent = new MailContent();
            mailContent.To = to;
            mailContent.Subject = subject;
            mailContent.Body = body;

            return mailContent;
        }
    }
}
