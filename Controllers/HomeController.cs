using ClinicMVC.Context;
using ClinicMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Doctor> doctors;
              doctors  =_context.Doctors.Include(d=>d.Department).ToList();
            return View(doctors);
        }
    }
}
