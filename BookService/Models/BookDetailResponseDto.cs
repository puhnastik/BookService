using System;
using Newtonsoft.Json;

namespace BookService.Models
{
    public class BookDetailResponseDto
    {
        [JsonProperty("Id")]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public DateTime PublishDate { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public Author Author { get; set; }
    }
}