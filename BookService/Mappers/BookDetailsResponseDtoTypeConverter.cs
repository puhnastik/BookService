using AutoMapper;
using BookService.IoC;
using BookService.Models;

namespace BookService.TypeConverters
{
    public class BookDetailsResponseDtoTypeConverter : IBookDetailsResponseDtoTypeConverter
    {
        private readonly IMapper _mapper;

        public BookDetailsResponseDtoTypeConverter(IMapper mapper)
        {
            _mapper = mapper;
        }

        public BookDetailResponseDto ToBookDetailsResponseDto(Book book)
        {
            return _mapper.Map<BookDetailResponseDto>(book);
        }
    }
}