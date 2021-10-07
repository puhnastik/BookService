using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookService.Models;
using BookService.TypeConverters;

namespace BookService.Services
{
    public class MappingService : IMappingService
    {
        private readonly IBookResponseDtoTypeConverter _bookResponseDtoTypeConverter;

        public MappingService(IBookResponseDtoTypeConverter bookResponseDtoTypeConverter)
        {
            _bookResponseDtoTypeConverter = bookResponseDtoTypeConverter;
        }

        public BookResponseDto Map(Book book)
        {
            return _bookResponseDtoTypeConverter.ToBookResponseDto(book);
        }
    }
}