using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using BookService.Models;
using BookService.Services;

namespace BookService.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        // GET: api/Books
        public IQueryable<BookResponseDto> GetBooks()
        {
            return _bookService.GetBooks();
        }

        // GET: api/Books/5
        [ResponseType(typeof(BookResponseDto))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            var book = await _bookService.GetBook(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // GET: api/Books/5/details
        [Route("api/books/{id}/details")]
        [ResponseType(typeof(BookDetailResponseDto))]
        public async Task<IHttpActionResult> GetBookDetails(int id)
        {
            var book = await _bookService.GetBookDetails(id);

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

            await _bookService.UpdateBook(id, bookDto);

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

            var bookResponseDto = await _bookService.AddBook(bookRequestDto);

            //return with location header
            return CreatedAtRoute("DefaultApi", new { id = bookResponseDto.BookId }, bookResponseDto);
        }

        // DELETE: api/Books/5
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            await _bookService.DeleteBook(id);

            return Ok();
        }
    }
}