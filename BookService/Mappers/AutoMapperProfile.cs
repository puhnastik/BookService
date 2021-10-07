using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookService.Models;

namespace BookService.TypeConverters
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Book, BookResponseDto>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Name));
            CreateMap<BookRequestDto, Book>().ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.AuthorName));
            CreateMap<string, Author>().ForMember(dest => dest.Name, opt => opt.MapFrom(src => src));
            CreateMap<Book, BookDetailResponseDto>();
        }
    }
}