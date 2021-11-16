using System.ComponentModel.DataAnnotations;

namespace gStringKustomGuitars.Web.Models
{
    public class CategoryModel
    {
        [Display(Name = "Category ID")]
        public int id { get; set; }

        [Required]
        [StringLength(6, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [RegularExpression("^.*$", ErrorMessage = "Only Alphabets and Numbers allowed.")]
        [Display(Name = "Category Code")]
        public string code { get; set; }

        [Required]
        [Display(Name = "Category Name")]
        public string name { get; set; }

        [Display(Name = "IsEnabled")]
        public bool isactive { get; set; }
    }
}
