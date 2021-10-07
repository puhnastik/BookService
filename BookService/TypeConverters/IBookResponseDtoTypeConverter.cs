using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookService.Models;

namespace BookService.TypeConverters
{
    public interface IBookResponseDtoTypeConverter
    {
        BookResponseDto ToBookResponseDto(Book book);
    }
}
