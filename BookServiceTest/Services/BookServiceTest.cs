using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using AutoFixture.NUnit3;
using BookService.Models;
using BookService.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace BookServiceTest.Services
{
    [TestFixture]
    public class BookServiceTest
    {
        // [Theory]
        // [MoqData]
        // public void BookService_GetBookTest(int id,
        //     Book book,
        //     BookResponseDto bookResponseDto,
        //     [Frozen] Mock<BookServiceContext> context,
        //     [Frozen] Mock<IMappingService> mappingService,
        //     BookService.Services.BookService bookService)
        // {
        //     //Arrange
        //     context.Setup(x => x.Books).Returns(book);
        //
        //     //Act
        //     var result = bookService.GetBook(id);
        //
        //     //Assert
        //     result.Should().Be(bookResponseDto);
        //
        //
        // }
    }
}
