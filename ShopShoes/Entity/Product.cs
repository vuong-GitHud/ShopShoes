using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopshose.Data.Entity
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Price { get; set; }
        public int Amount { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
