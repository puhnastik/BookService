using System;
using AutoMapper;
using BookService.Models;

namespace BookService.TypeConverters
{
    public class BookResponseDtoTypeConverter : IBookResponseDtoTypeConverter
    {
        private readonly IMapper _mapper;

        public BookResponseDtoTypeConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BookResponseDto ToBookResponseDto(Book book)
        {
            return _mapper.Map<BookResponseDto>(book);
        }
    }
}