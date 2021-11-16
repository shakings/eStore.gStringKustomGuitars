using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace gStringKustomGuitars.Web.Models
{
    public class ProductModel
    {
        [Display(Name = "Product ID")]
        public int id { get; set; }
        [Display(Name = "Product Code")]
        public string code { get; set; }
        [Display(Name = "Product Name")]
        public string name { get; set; }
        [Display(Name = "Product Description")]
        public string description { get; set; }
        [Display(Name = "Product Price")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public string price { get; set; }
        [Display(Name = "Product Photo")]
        public string image { get; set; }
        [Display(Name = "Category Id")]
        public int categoryId { get; set; }
        [Display(Name = "Category Name")]
        public string categoryName { get; set; }

        public IFormFile UploadFile { get; set; }


    }
}
