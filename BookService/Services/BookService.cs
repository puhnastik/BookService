using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
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
            Book book = await _context.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .FirstOrDefaultAsync();

            BookResponseDto bookResponseDto = _mappingService.Map(book);
            
            return bookResponseDto;
        }

        public IQueryable<BookResponseDto> GetBooks()
        {
            return  _context.Books.ProjectTo<BookResponseDto>(_mappingService.GetConfiguration());
        }

        public async Task UpdateBook(int id, BookRequestDto bookDto)
        {
            Book book = await _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.BookId == id);

            if (book == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            book = _mappingService.Map(bookDto);

            await _context.SaveChangesAsync();
        }

        public async Task<BookResponseDto> AddBook(BookRequestDto bookRequestDto)
        {
            var book = _mappingService.Map(bookRequestDto);

            _context.Books.Add(book);
            await _context.SaveChangesAsync();

            var bookResponseDto = _mappingService.Map(book);

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
            var book = await _context.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .FirstOrDefaultAsync();
            
            var bookDto = _mappingService.MapToBookDetailResponseDto(book);
            return bookDto;
        }
    }
}