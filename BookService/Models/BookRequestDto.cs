using System;
using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class BookRequestDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }

        [Required]
        public string AuthorName { get; set; }
    }
}