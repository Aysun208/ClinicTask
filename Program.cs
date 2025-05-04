using ClinicMVC.Context;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            string connectionstr = "Server=localhost\\SQLEXPRESS;Database=ClinicDb;Trusted_Connection = True;TrustServerCertificate=True";
            builder.Services.AddDbContext<AppDbContext>(opt=>opt.UseSqlServer(connectionstr));
            builder.Services.AddControllersWithViews();
            var app = builder.Build();
            app.UseStaticFiles();

          
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
