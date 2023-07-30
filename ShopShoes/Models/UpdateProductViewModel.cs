namespace ShopShoes.Models
{
    public class UpdateProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }
        public string ImageFileName { get; set; }
    }
}
