﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace BookService.Models
{
    public class BookResponseDto
    {
        [JsonProperty("Id")]
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
    }
}