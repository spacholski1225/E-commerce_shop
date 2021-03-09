using Microsoft.AspNetCore.Http;
using Shop.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.ViewModels
{
    public class CreateVideoViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The title is too long! Maximum is 50")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public EVideoCategory? Category { get; set; }
        public IFormFile Photo { get; set; }
    }
}
