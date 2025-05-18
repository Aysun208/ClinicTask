using System.ComponentModel.DataAnnotations.Schema;

namespace ClinicMVC.Models
{
    public class Doctor:BaseModel
    {
        public string Name { get; set; }
        public string ? ImgUrl {  get; set; }
        [NotMapped]
        public IFormFile ImageUpload { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
    }
}
