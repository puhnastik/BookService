using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using BookService.Exceptions;
using BookService.Models;

namespace BookService.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly BookServiceContext _context;


        public BookRepository(BookServiceContext context)
        {
            _context = context;
        }

        public async Task<Book> GetBook(int id)
        {
            Book book = await _context.Books.Include(b => b.Author).SingleOrDefaultAsync(b => b.BookId == id);
            return book;
        }

        public IQueryable<Book> GetBooks()
        {
            return _context.Books;
        }

        public async Task<int> InsertBook(Book book)
        {
            _context.Books.Add(book);
            return await _context.SaveChangesAsync();
        }

        public async Task DeleteBook(int id)
        {

            Book book = await _context.Books.FindAsync(id);
            
            if (book == null)
            {
                throw new BookNotFoundException(id);
            }
            
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateBook(Book book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }

}