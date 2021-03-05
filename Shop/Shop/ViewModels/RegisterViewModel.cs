using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class RegisterViewModel
    {
        [Required] 
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "Wrong! Your confirm password is not the same.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Too long!")]
        public string  FirstName { get; set; }
        [Required]
        [MaxLength(70,ErrorMessage ="Too long!")]
        public string  LastName { get; set; }

        [MaxLength(70, ErrorMessage = "Too long!")]

        public string City { get; set; }
    }
}
