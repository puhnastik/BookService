using System.Linq;
using System.Threading.Tasks;
using BookService.Models;

namespace BookService.Services
{
    public interface IBookService
    {
        Task<BookResponseDto> GetBook(int id);
        IQueryable<BookResponseDto> GetBooks();
        Task UpdateBook(int id, BookRequestDto bookDto);
        Task<BookResponseDto> AddBook(BookRequestDto bookRequestDto);
        Task DeleteBook(int id);
        Task<BookDetailResponseDto> GetBookDetails(int id);
    }
}
