using Shop.Models.ProductModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Models
{
    public class Ebook : Product
    {
        public int EbookId { get; set; }


        [Required]
        public EEbookCategory? Category { get; set; }
    }
}
