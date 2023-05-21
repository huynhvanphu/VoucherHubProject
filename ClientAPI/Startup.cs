using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ClientAPI.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ClientAPI
{
    public class Startup
    {
        public static string RootPath { get; set; }

        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            RootPath = env.ContentRootPath; //Cau hinh root path de truy cap media files
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddMvc();
            services.AddHttpContextAccessor();
            services.AddSession(option =>
            {
                option.Cookie.Name = "VoucherHub";
                option.IdleTimeout = new TimeSpan(0, 60, 0);

            });
            services.AddSingleton<CustomerService>();
            services.AddSingleton<StoreOwnerService>();
            services.AddSingleton<SystemService>();
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

            app.UseSession();

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();  //Xac thuc danh tinh

            app.UseAuthorization();     //Xac thuc quyen truy cap

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages(); //Tich hop Razor Pages vao trong mo hinh MVC
            });
        }
    }
}
