using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Net;
using System.Web.Http;
using AutoMapper.QueryableExtensions;
using BookService.Exceptions;
using BookService.Models;
using BookService.Repositories;
using Castle.Core.Logging;


namespace BookService.Services
{
    public class BookService : IBookService
    {
        public ILogger Logger { get; set; }

        private readonly BookServiceContext _context;
        private readonly IMappingService _mappingService;
        private readonly IBookRepository _repository;

        public BookService(IBookRepository repository, IMappingService mappingService, BookServiceContext context)
        {
            _context = context;
            _repository = repository;
            _mappingService = mappingService;
        }

        public async Task<BookResponseDto> GetBook(int id)
        {
            var book = await _repository.GetBook(id);
            
            BookResponseDto bookResponseDto = _mappingService.Map(book);
            
            return bookResponseDto;
        }

        public IQueryable<BookResponseDto> GetBooks()
        {
            var books = _repository.GetBooks();
            return books.ProjectTo<BookResponseDto>(_mappingService.GetConfiguration());
        }

        public async Task UpdateBook(int id, BookRequestDto bookDto)
        {
            var book = await _repository.GetBook(id);

            if (book == null)
            {
                throw new BookNotFoundException(id);
            }

            book = _mappingService.Map(bookDto, book);
            await _repository.UpdateBook(book);
        }

        public async Task<BookResponseDto> AddBook(BookRequestDto bookRequestDto)
        {
            var book = _mappingService.Map(bookRequestDto);

            Logger.Debug("Adding new book");
            await _repository.InsertBook(book);

            var bookResponseDto = _mappingService.Map(book);

            return bookResponseDto;
        }

        public async Task DeleteBook(int id)
        {
            await _repository.DeleteBook(id);
        }

        public async Task<BookDetailResponseDto> GetBookDetails(int id)
        {
            var book = await _repository.GetBook(id);
            
            var bookDto = _mappingService.MapToBookDetailResponseDto(book);
            return bookDto;
        }
    }
}