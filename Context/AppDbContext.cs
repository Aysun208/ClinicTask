using ClinicMVC.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Context
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public DbSet<Doctor> Doctors {  get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
