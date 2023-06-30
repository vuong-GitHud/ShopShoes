namespace ShopShoes.Models
{
    public class AddProductViewModel
    {
        public string Name { get; set; }
        public long Price { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }
    }
}
