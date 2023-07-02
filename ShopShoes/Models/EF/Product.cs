using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopShoes.Models.EF
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Price { get; set; }
        public int Amount { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }
    }
}
