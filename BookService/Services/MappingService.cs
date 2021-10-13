using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using BookService.Models;
using BookService.TypeConverters;

namespace BookService.Services
{
    public class MappingService : IMappingService
    {
        private readonly IBookResponseDtoTypeConverter _bookResponseDtoTypeConverter;
        private readonly IConfigurationProvider _configuration;
        private readonly IBookRequestDtoTypeConverter _bookRequestDtoTypeConverter;
        private readonly IBookDetailsResponseDtoTypeConverter _bookDetailsResponseDtoTypeConverter;

        public IConfigurationProvider GetConfiguration()
        {
            return _configuration;
        }

        public MappingService(IConfigurationProvider configuration,
            IBookRequestDtoTypeConverter bookRequestDtoTypeConverter,
            IBookResponseDtoTypeConverter bookResponseDtoTypeConverter,
            IBookDetailsResponseDtoTypeConverter bookDetailsResponseDtoTypeConverter)
        {
            _configuration = configuration;
            _bookResponseDtoTypeConverter = bookResponseDtoTypeConverter;
            _bookRequestDtoTypeConverter = bookRequestDtoTypeConverter;
            _bookDetailsResponseDtoTypeConverter = bookDetailsResponseDtoTypeConverter;
        }

        public BookResponseDto Map(Book book)
        {
            return _bookResponseDtoTypeConverter.ToBookResponseDto(book);
        }

        public Book Map(BookRequestDto book)
        {
            return _bookRequestDtoTypeConverter.ToBook(book);
        }

        public Book Map(BookRequestDto bookRequestDto, Book book)
        {
            return _bookRequestDtoTypeConverter.ToBook(bookRequestDto, book);
        }

        public BookDetailResponseDto MapToBookDetailResponseDto(Book book)
        {
            return _bookDetailsResponseDtoTypeConverter.ToBookDetailsResponseDto(book);
        }
    }
}