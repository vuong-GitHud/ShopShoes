namespace ShopShoes.Models
{
    public class UpdateProductViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }
    }
}
