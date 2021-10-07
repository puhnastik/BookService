using BookService.Models;

namespace BookService.TypeConverters
{
    public interface IBookRequestDtoTypeConverter
    {
        Book ToBook(BookRequestDto book);
    }
}
