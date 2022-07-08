using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using Online_Learn.Models;

namespace Online_Learn {
    public class Startup {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSession();
            services.AddControllersWithViews();
            var connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<Online_LearnContext>(options => options.UseSqlServer(connection));
            //services
                //.AddAuthentication().AddFacebook(facebookOptions =>
                //{
                //    IConfigurationSection facebookAuthNSection = Configuration.GetSection("Authentication:Facebook");
                //    facebookOptions.AppId = facebookAuthNSection["AppId"];
                //    facebookOptions.AppSecret = facebookAuthNSection["AppSecret"];
                //    // Thiết lập đường dẫn Facebook chuyển hướng đến
                //    facebookOptions.CallbackPath = "/Login/Login_Facebook";
                //})
                //.AddGoogle(googleOptions =>
                //{
                //    // Đọc thông tin Authentication:Google từ appsettings.json
                //    IConfigurationSection googleAuthNSection = Configuration.GetSection("Authentication:Google");

                //    // Thiết lập ClientID và ClientSecret để truy cập API google
                //    googleOptions.ClientId = googleAuthNSection["ClientId"];
                //    googleOptions.ClientSecret = googleAuthNSection["ClientSecret"];
                //    // Cấu hình Url callback lại từ Google (không thiết lập thì mặc định là /signin-google)
                //    googleOptions.CallbackPath = "/Login_Google";

                //});
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
            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
