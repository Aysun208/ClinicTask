using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ViewModels
{
    public class LoginUserVM
    {
        [Required]
        public string UsernameOrEmailAdress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public bool IsPersistent { get; set; }
    }
}
