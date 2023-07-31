using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using PruebaIngresoBibliotecario.Api.Errors;
using PruebaIngresoBibliotecario.Application.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace PruebaIngresoBibliotecario.Api.Middleware
{
    public class ExceptionMiddleware
    {

        private readonly RequestDelegate Next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            this.Next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await this.Next(context);
            }
            catch (Exception ex)
            {
                context.Response.ContentType = "application/json";

                int statusCode = (int)HttpStatusCode.BadRequest;
                string result = string.Empty;

                switch (ex)
                {
                    case NotFoundException notFound:
                        statusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case ValidationException validation:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        string validationJson = JsonConvert.SerializeObject(validation.Errors);
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, validationJson));
                        break;
                    case BadRequestException badRequest:
                        statusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case CustomMessageException custom:
                        statusCode = custom.StatusCode;
                        result = JsonConvert.SerializeObject(new CodeErrorException(statusCode, custom.Message));
                        break;
                }

                if (string.IsNullOrEmpty(result))
                    result = JsonConvert.SerializeObject(new CodeErrorException(statusCode));

                context.Response.StatusCode = statusCode;
                await context.Response.WriteAsync(result);
            }
        }
    }
}
