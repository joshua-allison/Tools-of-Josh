using System.ComponentModel.DataAnnotations;

namespace TheDigitalToolbox.Models
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Please enter a user name.")]
        [StringLength(255)]
        public string Username { get; set; }
        [Required(ErrorMessage = "Please enter your first name.")]
        [StringLength(255)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Please enter your last name.")]
        [StringLength(255)]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please enter an email address.")]
        [DataType(DataType.EmailAddress)]
        public string Email{ get; set; }

        [Required(ErrorMessage = "Please enter a password.")]
        [DataType(DataType.Password)]
        [Compare("ConfirmPassword")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please confirm your password.")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        public string ConfirmPassword { get; set; }
    }
}