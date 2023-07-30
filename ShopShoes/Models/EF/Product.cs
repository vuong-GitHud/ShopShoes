using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string ImageFileName { get; set; }
        //[Required(ErrorMessage ="Please choose font image")]
        //[Display (Name = "Font Image")]
        //[NotMapped]
        //public IFormFile FontImage { get; set; }
    }
}
