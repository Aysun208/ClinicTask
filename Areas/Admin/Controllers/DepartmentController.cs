using ClinicMVC.Areas.ViewModels.DepartmentVMs;
using ClinicMVC.Context;
using ClinicMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DepartmentController : Controller
    {
        private readonly AppDbContext _context;
        public DepartmentController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            List<Department> departments = _context.Departments.Include(d => d.Doctors).ToList();
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
        public IActionResult Update(int id)
        {
            Department? existingDepartment = _context.Departments.Find(id);
            if (existingDepartment == null) { return NotFound("Department movcud deyil"); }
            return View(nameof(Create), existingDepartment);
        }

        [HttpPost]
        public IActionResult Update(Department department)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), department);
            }
            Department? existingDepartment = _context.Departments.AsNoTracking().
                  FirstOrDefault(d => d.Id == department.Id);
            if (existingDepartment == null)
            {
                return NotFound("Department movcud deyil");
            }
            _context.Departments.Update(department);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult AssignServices(int id)
        {
            Department? existingDepartment = _context.Departments.Find(id);
            if (existingDepartment == null) { return NotFound("Department movcud deyil"); }
            BatchAssignVM batchAssignVM = new BatchAssignVM()
            {
                CategoryId = id,

                AllServices = _context.Doctors.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name }).ToList(),
                DoctorIds = new List<int>()

            };
            return View(batchAssignVM);

        }
        [HttpPost]
        public IActionResult AssignServices(BatchAssignVM model)
        {
           var doctors =  _context.Doctors.Where(d => model.DoctorIds.Contains(d.Id));
            foreach(var doctor in doctors)
            {
                doctor.DepartmentId = model.DepartmentId;
            };
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}





