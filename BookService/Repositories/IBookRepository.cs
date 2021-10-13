using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService.Models;

namespace BookService.Repositories
{
    public interface IBookRepository
    {
        Task<Book> GetBook(int id);
        IQueryable<Book> GetBooks();
        Task<int> InsertBook(Book book);
        Task DeleteBook(int id);
        Task UpdateBook(Book book);
    }
}
