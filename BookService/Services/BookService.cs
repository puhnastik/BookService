using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using BookService.Models;

namespace BookService.Services
{
    public class BookService : IBookService
    {
        private readonly BookServiceContext _context;
        private readonly IMappingService _mappingService;

        public BookService(BookServiceContext context, IMappingService mappingService)
        {
            _context = context;
            _mappingService = mappingService;
        }

        public async Task<BookResponseDto> GetBook(int id)
        {
            //     BookResponseDto book = await _context.Books.Include(b => b.Author)
            //         .Where(b => b.BookId == id)
            //         .Select(b => new BookResponseDto { Title = b.Title, Genre = b.Genre, Author = b.Author.Name, BookId = b.BookId})
            // .FirstOrDefaultAsync();
            Book book = await _context.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .FirstOrDefaultAsync();

            BookResponseDto bookResponseDto = _mappingService.Map(book);
            
            return bookResponseDto;
        }

        public IQueryable<BookResponseDto> GetBooks()
        {
            return _context.Books.Select(
                b => new BookResponseDto { Title = b.Title, Genre = b.Genre, Author = b.Author.Name, BookId = b.BookId});
        }

        public async Task UpdateBook(int id, BookRequestDto bookDto)
        {
            Book book = await _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Genre = bookDto.Genre;
            book.Price = bookDto.Price;
            book.PublishDate = bookDto.PublishDate;
            book.Author.Name = bookDto.AuthorName;

            await _context.SaveChangesAsync();
        }

        public async Task<BookResponseDto> AddBook(BookRequestDto bookRequestDto)
        {
            Book book = new Book
            {
                Title = bookRequestDto.Title,
                Description = bookRequestDto.Description,
                Genre = bookRequestDto.Genre,
                Price = bookRequestDto.Price,
                PublishDate = bookRequestDto.PublishDate,
                Author = new Author { Name = bookRequestDto.AuthorName }
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            BookResponseDto bookResponseDto = new BookResponseDto
            {
                Title = book.Title,
                Author = book.Author.Name,
                Genre = book.Genre,
                BookId = book.BookId
            };

            return bookResponseDto;
        }

        public async Task DeleteBook(int id)
        {
            Book book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

        public async Task<BookDetailResponseDto> GetBookDetails(int id)
        {
            BookDetailResponseDto book = await _context.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .Select(b => new BookDetailResponseDto { Title = b.Title, Genre = b.Genre, Author = b.Author, BookId = b.BookId, Description = b.Description, Price = b.Price, PublishDate = b.PublishDate})
                .FirstOrDefaultAsync();
            return book;
        }
    }
}