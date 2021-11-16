namespace gStringKustomGuitars.Api.Domain.Categories.Models.Dtos
{
    public class ProductPsResultDto
    {
        public int id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string price { get; set; }
        public string image { get; set; }
        public string categoryName { get; set; }
        public int categoryId { get; set; }
    }
}
