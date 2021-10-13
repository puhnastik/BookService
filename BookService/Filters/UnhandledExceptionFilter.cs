using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
using BookService.Exceptions;
using Castle.Core.Logging;


namespace BookService.Filters
{
    public class UnhandledExceptionFilter : ExceptionFilterAttribute {
        private readonly ILogger _logger;

        public UnhandledExceptionFilter(ILogger logger)
        {
            _logger = logger;
        }

        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;

            if (exception is BookNotFoundException)
            {
                _logger.Debug(exception.GetBaseException().Message, exception);
                throw new HttpResponseException(HttpStatusCode.NotFound);

            }

            _logger.Error("Unhandled exception occurred: " + exception.GetBaseException().Message, exception);
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}