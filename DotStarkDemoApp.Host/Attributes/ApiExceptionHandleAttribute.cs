using DotStarkDemoApp.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Http.Tracing;

namespace DotStarkDemoApp.Host.Attributes
{
    public class ApiExceptionHandleAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext context)
        {
            var exception = context.Exception;

            if (exception is ValidationException)
            {
                var resp = new HttpResponseMessage(HttpStatusCode.BadRequest) { 
                    Content = new StringContent(exception.Message), 
                    ReasonPhrase = "ValidationException", 
                };
                throw new HttpResponseException(resp);
            }
            else if (exception is ValidationException)
            {
                throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.Unauthorized, new ServiceResponseModel()
                {
                    IsSuccessStatusCode = false,
                    StatusCode = HttpStatusCode.Unauthorized,
                    ReasonPhrase = "Unauthorized",
                    Message = string.Empty,
                    Data = string.Empty
                }));
            }
            else
            {
                throw new HttpResponseException(context.Request.CreateResponse(HttpStatusCode.InternalServerError, new ServiceResponseModel()
                {
                    IsSuccessStatusCode = false,
                    StatusCode = HttpStatusCode.InternalServerError,
                    ReasonPhrase = "InternalServerError",
                    Message = exception.Message,
                    Data = string.Empty
                }));
            }

        }
    }
}