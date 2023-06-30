namespace ShopShoes.Models.EF
{
    public class Oder
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int AmountOder { get; set; }
        public int CategoryID { get; set; }

    }
}
