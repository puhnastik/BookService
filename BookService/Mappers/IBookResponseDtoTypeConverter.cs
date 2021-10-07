using BookService.Models;

namespace BookService.TypeConverters
{
    public interface IBookResponseDtoTypeConverter
    {
        BookResponseDto ToBookResponseDto(Book book);
    }
}
