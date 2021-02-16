using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmpikClone.Models
{
    public class Album : IProduct
    {
        [Key]
        public int IdAlbum { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Too long!")]

        public string Title { get; set; }

        [Required]
        [StringLength(100)]
        public string Author { get; set; }

        [StringLength(500, ErrorMessage = "Too long!")]
        public string Description { get; set; }

        [Required]
        [Range(0, 999.99)]
        public float Price { get; set; }

        [Required(ErrorMessage = "Type!")]
        public string Type { get; set; }
    }
}
