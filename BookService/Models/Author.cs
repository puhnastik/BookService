using System.ComponentModel.DataAnnotations;

namespace BookService.Models
{
    public class Author
    {
        public int AuthorId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}