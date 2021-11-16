using System.ComponentModel.DataAnnotations;

namespace gStringKustomGuitars.Web.Models
{
    public class LoginModel
    {
        [Display(Name = "Name")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string name { get; set; }
        [Display(Name = "Surname")]
        [Required(ErrorMessage = "Field can't be empty")]
        public string surname { get; set; }

        [Display(Name = "Email Address")]
        [Required(ErrorMessage = "Field can't be empty")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string password { get; set; }

    }
}
