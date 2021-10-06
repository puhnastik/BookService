using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookService.Models;

namespace BookService.Controllers
{
    public class BooksController : ApiController
    {
        private BookServiceContext db = new BookServiceContext();

        // GET: api/Books
        public IQueryable<BookResponseDto> GetBooks()
        {
            return db.Books.Select(b => new BookResponseDto { Title = b.Title, Genre = b.Genre, Author = b.Author.Name });
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookResponseDto))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            BookResponseDto book = await db.Books.Include(b => b.Author)
                .Where(b => b.BookId == id)
                .Select(b => new BookResponseDto { Title = b.Title, Genre = b.Genre, Author = b.Author.Name })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, BookRequestDto bookDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = db.Books.Find(id);

            if (book == null) 
            {
                return StatusCode(HttpStatusCode.NotFound);
            }

            book.Title = bookDto.Title;
            book.Description = bookDto.Description;
            book.Genre = bookDto.Genre;
            book.Price = bookDto.Price;
            book.PublishDate = bookDto.PublishDate;
            //todo: add author
            await db.SaveChangesAsync();
           
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(BookResponseDto))]
        public async Task<IHttpActionResult> PostBook(BookRequestDto bookRequestDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = new Book { Title = bookRequestDto.Title,
                Description = bookRequestDto.Description,
                Genre = bookRequestDto.Genre,
                Price = bookRequestDto.Price,
                PublishDate = bookRequestDto.PublishDate,
                Author = new Author { Name = bookRequestDto.AuthorName }
            };

            db.Books.Add(book);
            await db.SaveChangesAsync();

            BookResponseDto bookResponseDto = new BookResponseDto
            {
                Title = book.Title,
                Author = book.Author.Name,
                Genre = book.Genre
            };

            //return with location header
            return CreatedAtRoute("DefaultApi", new { id = book.BookId }, bookResponseDto);
        }

        // DELETE: api/Books/5

        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.BookId == id) > 0;
        }
    }
}