﻿using System;
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
        public decimal Price { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateCreate { get; set; }
        public string Status { get; set; }
    }
}
