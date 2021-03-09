using Shop.Models.Enums;
using Shop.Models.ProductModel;
using System.ComponentModel.DataAnnotations;

namespace Shop.Models.Videos
{
    public class Video : Product
    {
        public int VideoId { get; set; }
        [Required]
        public EVideoCategory?  Category { get; set; }
    }
}
