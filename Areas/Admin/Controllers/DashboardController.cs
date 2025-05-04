using ClinicMVC.Context;
using ClinicMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace ClinicMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        private readonly AppDbContext _context;
        public DashboardController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Department> departments = _context.Departments.Include(d=>d.Doctors).ToList();
            return View(departments);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Department department)
        {
            if (!ModelState.IsValid) 
            {
                return BadRequest("Something went wrong");
            }
            else 
            {
                _context.Departments.Add(department);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));

           
        }
        public IActionResult Delete(int id)
        {
            Department? department = _context.Departments.Find(id);
            if (department == null)
            {
                return NotFound("Department movcud deyil");
            }
            else
            { 
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
