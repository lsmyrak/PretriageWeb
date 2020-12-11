using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pretriage.Context;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace PretriageWeb
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
            //    services.AddIdentity<IdentityUser, IdentityRole>()
            //        .AddEntityFrameworkStores<PretriageContext>().AddDefaultTokenProviders();

            services.AddOptions();
            services.AddControllersWithViews();
        

            services.AddDbContext<PretriageContext>
                (options => options.UseSqlServer(Configuration
                .GetConnectionString("SqlServerHome")));
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var solutionAssemblies = Directory.GetFiles(
            AppDomain.CurrentDomain.BaseDirectory,
            "Pretriage*.dll")
            .Select(Assembly.LoadFrom);

            foreach (var assembly in solutionAssemblies)
            {
                builder.RegisterAssemblyModules(assembly);
            }
        }

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
                // app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
          

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
