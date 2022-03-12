using TheDigitalToolbox.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity;

namespace TheDigitalToolbox
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
            services.AddControllersWithViews();

            services.AddDbContext<ToolboxContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ToolBoxContext")));

            services.AddHttpContextAccessor();

            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession();

            services.AddIdentity<User, IdentityRole>(options => {
                options.Password.RequiredLength = 9;
            }).AddEntityFrameworkStores<ToolboxContext>()
                .AddDefaultTokenProviders();

            services.AddTransient<ITheDigitalToolBoxDBUnitOfWork, TheDigitalToolBoxDBUnitOfWork>();
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
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

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

                // route for Admin area
                endpoints.MapAreaControllerRoute(
                    name: "admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=UserController}/{action=Index}/");
            });
            
            ToolboxContext.CreateAdminUser(app.ApplicationServices).Wait(); // calls the create admin user function defined in ToolboxContext
        }
    }
}
