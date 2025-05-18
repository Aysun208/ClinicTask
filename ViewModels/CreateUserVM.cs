using System.ComponentModel.DataAnnotations;

namespace ClinicMVC.ViewModels
{
    public class CreateUserVM
    {
        [Required]
        [MaxLength(25)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(40)]
        public string LastName { get; set; }
        [Required]
        [MaxLength (20)]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [DataType(DataType.Password) , Compare(nameof(Password) , ErrorMessage ="ConfirmPassword do not match password")]
        public string ConfirmPassword { get; set; }


    }
}
