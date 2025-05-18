using ClinicMVC.Context;
using ClinicMVC.Models;
using ClinicMVC.Utilities.File;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClinicMVC.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DoctorController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public DoctorController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index()
        {
            List<Doctor> doctors = _context.Doctors.Include(d => d.Department).ToList();
            return View(doctors);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Something went wrong");
            }
            if (!doctor.ImageUpload.CheckImageType())
            {
                ModelState.AddModelError("ImageUpload", "File must be Image format");
                return View(doctor);
            }
            string filename = doctor.ImageUpload.DownloadImage(_webHostEnvironment, @"\UploadImages\Doctors\");
            doctor.ImgUrl = filename;
            _context.Doctors.Add(doctor);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Doctor? doctor = _context.Doctors.Find(id);
            if (doctor == null)
            {
                return NotFound("Doctor movcud deyil");
            }
            else
            {
                _context.Doctors.Remove(doctor);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(int id)
        {
            Doctor? existingDoctor = _context.Doctors.Find(id);
            if (existingDoctor == null) { return NotFound("Doctor movcud deyil"); }
            return View(nameof(Create), existingDoctor);
        }

        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            if (!ModelState.IsValid)
            {
                return View(nameof(Index), doctor);
            }
            Doctor? existingDoctor = _context.Doctors.AsNoTracking().
                  FirstOrDefault(d => d.Id == doctor.Id);
            if (existingDoctor == null)
            {
                return NotFound("Doctor movcud deyil");
            }
            _context.Doctors.Update(doctor);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
