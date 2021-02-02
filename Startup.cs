using HitServicesCore.Filters;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebPosLicense.Models;

namespace WebPosLicense
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            LoginUser usr = new LoginUser();
            services.AddControllersWithViews().AddJsonOptions(options => options.JsonSerializerOptions.PropertyNamingPolicy = null);
            services.AddMemoryCache();
            services
    .AddMvc(
    options =>
    {

        options.Filters.Add(typeof(LoginFilter));
        options.EnableEndpointRouting = false;
    })
  .SetCompatibilityVersion(CompatibilityVersion.Latest)
  .AddJsonOptions(o =>
  {
      o.JsonSerializerOptions.PropertyNamingPolicy = null;
      o.JsonSerializerOptions.DictionaryKeyPolicy = null;
  });
            services.AddSingleton<LoginUser>();
            services.AddSingleton<LoginFilter>();
            services.Configure<MyConfiguration>(Configuration.GetSection("MyConfig"));
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(62);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
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
            app.UseSession();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
