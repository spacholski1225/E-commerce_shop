using Microsoft.AspNetCore.Http;
using Shop.Models;
using System.ComponentModel.DataAnnotations;

namespace Shop.ViewModels
{
    public class CreateEbookViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "The title is too long! Maximum is 50")]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        public ECategories? Category { get; set; }
        public IFormFile Photo { get; set; }
    }
}
