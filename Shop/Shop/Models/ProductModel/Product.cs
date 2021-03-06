using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models.ProductModel
{
    public abstract class Product
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The title is too long! Maximum is 50")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        
        public string PhotoPath { get; set; }

    }
}
