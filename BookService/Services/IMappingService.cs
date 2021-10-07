using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService.Models;

namespace BookService.Services
{
    public interface IMappingService
    {
        BookResponseDto Map(Book book);
    }
}
