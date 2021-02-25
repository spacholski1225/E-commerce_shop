using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Ebook
    {
        public int EbookId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The title is too long! Maximum is 50")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ECategories? Category { get; set; }
        public string PhotoPath { get; set; }
    }
}
