using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Results;
using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using BookService.Controllers;
using BookService.Models;
using BookService.Services;
using FluentAssertions;
using Moq;
using NUnit.Framework;


namespace BookServiceTest.Controllers
{
    [TestFixture]
    public class BooksControllerTests
    {
        #region Get Book

        [Theory]
        [AutoDomainData]
        public async Task BooksController_GetBookTest(int id, BookResponseDto book,
            [Frozen] Mock<IBookService> bookServiceMock,
            BooksController controller)
        {
            //Arrange
            bookServiceMock.Setup(x => x.GetBook(id)).ReturnsAsync(book);

            //Act
            var result = await controller.GetBook(id) as OkNegotiatedContentResult<BookResponseDto>;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<OkNegotiatedContentResult<BookResponseDto>>();
            result.Content.Should().Be(book);
        }

        [Theory]
        [AutoDomainData]
        public async Task BooksController_GetNonexistentBookTest(int id,
            [Frozen] Mock<IBookService> bookServiceMock,
            BooksController controller)
        {
            //Arrange
            bookServiceMock.Setup(x => x.GetBook(id)).ReturnsAsync((BookResponseDto)null);

            //Act
            var result = await controller.GetBook(id);

            //Assert
            result.Should().BeOfType<NotFoundResult>();
        }

        #endregion

        #region Bet Books

        [Theory]
        [AutoDomainData]
        public void BooksController_GetBooks([Frozen] Mock<IBookService> bookServiceMock, BooksController controller, IQueryable<BookResponseDto> bookResponseDtos)
        {
            //Arrange
            bookServiceMock.Setup(x => x.GetBooks()).Returns(bookResponseDtos); 

            //Act
            var result = controller.GetBooks();
            //Assert
            result.Should().BeEquivalentTo(bookResponseDtos);
        }

        [Theory]
        [AutoDomainData]
        public void BooksController_GetBooksEmptyList([Frozen] Mock<IBookService> bookServiceMock, BooksController controller)
        {
            //Arrange
            bookServiceMock.Setup(x => x.GetBooks()).Returns(Enumerable.Empty<BookResponseDto>().AsQueryable());

            //Act
            var result = controller.GetBooks();
            
            //Assert
            result.Should().BeEmpty();
        }

        #endregion

        #region Add Book

        [Theory]
        [AutoDomainData]
        public async Task BooksController_AddBook([Frozen] Mock<IBookService> bookServiceMock, BooksController controller,
            BookRequestDto bookRequestDto,
            BookResponseDto bookResponseDto)
        {
            //Arrange
            bookServiceMock.Setup(x => x.AddBook(bookRequestDto)).ReturnsAsync(bookResponseDto);

            //Act
            var result = await controller.PostBook(bookRequestDto) as CreatedAtRouteNegotiatedContentResult<BookResponseDto>;

            //Assert
            result.Should().NotBeNull();
            result.Should().BeOfType<CreatedAtRouteNegotiatedContentResult<BookResponseDto>>();
            result.Content.Should().Be(bookResponseDto);

            result.RouteName.Should().Be("DefaultApi");
            result.RouteValues["id"].Should().Be(result.Content.BookId);
        }

        #endregion
    }
}