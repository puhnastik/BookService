using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Filters;
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
            
            _logger.Error("Unhandled exception occurred: " + context.Exception.GetBaseException().Message, context.Exception);
            
            context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
        }
    }
}