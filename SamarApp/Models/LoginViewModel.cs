using System.ComponentModel.DataAnnotations;

namespace SamarApp.Models
{
    public class LoginViewModel
    {


        [Required(ErrorMessage = " User Name is Required !")]
        [MinLength(5 , ErrorMessage = "Invalid User Name !")]
        public string UserName { get; set; }


        [Required(ErrorMessage = "Password is Required !")]
        [MinLength(5, ErrorMessage = "Minimum Password Length is 5 ")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }



        //public override bool Equals(object obj)
        //{
        //    //Check for null and compare run-time types.
        //    if ((obj == null) || !this.GetType().Equals(obj.GetType()))
        //    {
        //        return false;
        //    }
        //    else
        //    {
        //        LoginViewModel Login = (LoginViewModel)obj;
        //        return (UserName == Login.UserName);
        //    }
        //}

    }
}
