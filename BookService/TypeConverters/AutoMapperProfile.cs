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
        }
    }
}