using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace BookService.Filters
{
    public class GlobalExceptionFilter : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
  //              Console.WriteLine(context.Exception.Message);
   //             context.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);

        }
    }
}