using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookService.Models;

namespace BookService.TypeConverters
{
    public class BookRequestDtoTypeConverter : IBookRequestDtoTypeConverter
    {
        private readonly IMapper _mapper;

        public BookRequestDtoTypeConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public Book ToBook(BookRequestDto book)
        {
            return _mapper.Map<Book>(book);
        }
    }
}