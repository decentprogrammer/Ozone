using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Ozone.BLL;
using Ozone.DAL;
using Ozone.DAL.Hubs;
using Ozone.DAL.Repositories;
using Ozone.Models;
using Ozone.UI.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ozone.UI
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
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            services.AddRazorPages()
            .AddRazorPagesOptions(options =>
            {
                options.Conventions.ConfigureFilter(new IgnoreAntiforgeryTokenAttribute());
            })
            .AddRazorRuntimeCompilation();
            services.AddSignalR();

            #region Register Repositories
            services.AddTransient<IUnitRepository, UnitRepository>();
            services.AddTransient<IChecklistRepository, ChecklistRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IVendorRepository, VendorRepository>();
            #endregion

            #region Register Services
            services.AddTransient<IVendorService, VendorService>();
            services.AddTransient<IUserService, UserService>();
            #endregion

            services.AddScoped<UserWidgetsDetails>();
            services.AddSingleton<ApplicationUserModel>();
            services.AddSingleton<EditUnitModel>();
            services.AddSingleton<ChecklistBuilderModel>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapHub<SignalDashboard>("/signalDashboard");
            });
        }
    }
}
