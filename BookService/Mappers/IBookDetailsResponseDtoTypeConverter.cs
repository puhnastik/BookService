using BookService.Models;

namespace BookService.TypeConverters
{
    public interface IBookDetailsResponseDtoTypeConverter
    {
        BookDetailResponseDto ToBookDetailsResponseDto(Book book);
    }
}
