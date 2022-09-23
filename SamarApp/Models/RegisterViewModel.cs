using System.ComponentModel.DataAnnotations;

namespace SamarApp.Models
{
    public class RegisterViewModel
    {

        public string UserName { get; set; }

        [Required(ErrorMessage = " Email is Required !")]
        [EmailAddress(ErrorMessage = "Invalid Email !")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is Required !")]
        [MinLength(5, ErrorMessage = "Minimum Password Length is 5 ")]
        public string Password { get; set; }

        public bool IsAgree { get; set; }



    }
}
