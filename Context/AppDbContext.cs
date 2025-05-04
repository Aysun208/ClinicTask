using ClinicMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Context
{
    public class AppDbContext:DbContext
    {
        public DbSet<Doctor> Doctors {  get; set; }
        public DbSet<Department> Departments { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options): base(options)
        {
            
        }
    }
}
