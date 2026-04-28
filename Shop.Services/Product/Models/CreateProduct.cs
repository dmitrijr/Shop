namespace Shop.Services.Models
{
    public class CreateProduct
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CountInStock { get; set; }
    }
}