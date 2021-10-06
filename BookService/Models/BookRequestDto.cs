using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

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