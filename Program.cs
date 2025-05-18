using ClinicMVC.Context;
using ClinicMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ClinicMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("MsSql"));
            });
            builder.Services.AddControllersWithViews();

            builder.Services.AddIdentity<AppUser,IdentityRole>
                (opt =>
                {
                    opt.User.RequireUniqueEmail = true;
                    opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                    opt.Password.RequiredLength = 8;
                    opt.Password.RequireNonAlphanumeric = true;
                    opt.Password.RequireLowercase = true;
                    opt.SignIn.RequireConfirmedEmail = true;
                    opt.Lockout.AllowedForNewUsers = true;
                    opt.Lockout.MaxFailedAccessAttempts = 4;
                    opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);

                }).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

            var app = builder.Build();
            app.UseStaticFiles();
            app.UseAuthentication();

          
                app.MapControllerRoute
                (
                  name: "areas",
                  pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}"
                );
         
            app.MapControllerRoute
                (
                name: "Default",
                pattern:"{Controller=Home}/{Action=Index}/{id?}"
                );

     

            app.Run();
        }
    }
}
