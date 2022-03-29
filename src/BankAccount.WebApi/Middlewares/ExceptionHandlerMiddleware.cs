using BankAccount.Application.Exceptions;
using BankAccount.Application.Extensions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;

namespace BankAccount.WebApi.Middlewares
{
    public class ExceptionHandlerMiddleware : IMiddleware
    {
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next(context);
            }
            catch (Exception e)
            {
                var response = context.Response;


                var statusCode = e switch
                {
                    ApplicationException => HttpStatusCode.BadRequest,
                    BadRequestException => HttpStatusCode.BadRequest,
                    NotFoundException => HttpStatusCode.NotFound,
                    _ => HttpStatusCode.InternalServerError
                };

                response.StatusCode = (int)statusCode;

                var message = statusCode != HttpStatusCode.InternalServerError ? e.Message : "Internal server error.";

                await response.WriteAsync(JsonSerializer.Serialize(message.Failure()));
            }
        }
    }
}
