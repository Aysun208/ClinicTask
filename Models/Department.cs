using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.Models
{
    public class Department:BaseModel
    {
        [Required, MinLength(3) , MaxLength(100)]
        public string Title { get; set; }
        public ICollection <Doctor>? Doctors { get; set; }
    }
}
