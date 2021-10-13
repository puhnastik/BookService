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
        AutoMapper.IConfigurationProvider GetConfiguration();
        BookResponseDto Map(Book book);
        Book Map(BookRequestDto book);
        Book Map(BookRequestDto bookRequestDto, Book book);
        BookDetailResponseDto MapToBookDetailResponseDto(Book book);
    }

    
}
