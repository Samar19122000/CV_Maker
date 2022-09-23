using Microsoft.AspNetCore.Identity;

namespace SamarApp.Models
{
    public class ApplicationUser:IdentityUser
    {
        public bool IsAgree { get; set; }


        public override bool Equals(object obj)
        {
            //Check for null and compare run-time types.
            if ((obj == null) || !this.GetType().Equals(obj.GetType()))
            {
                return false;
            }
            else
            {
                ApplicationUser Login = (ApplicationUser)obj;
                return (UserName == Login.UserName);
            }
        }

    }
}
