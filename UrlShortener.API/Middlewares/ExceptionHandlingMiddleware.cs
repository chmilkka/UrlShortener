﻿using System.Net;
using System.Text.Json;
using UrlShortener.Domain.Exceptions;

namespace UrlShortener.API.Middlewares
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            HttpStatusCode status;
            var stackTrace = string.Empty;
            string message;

            var exceptionType = exception.GetType();

            if (exceptionType == typeof(IncorrectCredentialsException))
            {
                message = exception.Message;
                status = HttpStatusCode.NotFound;
            }    
            else if (exceptionType == typeof(ExistingUserException))
            {
                message = exception.Message;
                status = HttpStatusCode.BadRequest;
            }
            else if (exceptionType == typeof(NotAuthorizedException))
            {
                message = exception.Message;
                status = HttpStatusCode.Forbidden;
            }
            else
            {
                message = exception.Message;
                stackTrace = exception.StackTrace;
                status = HttpStatusCode.InternalServerError;
            }



            var exceptionResult = JsonSerializer.Serialize(new { error = message, stackTrace });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)status;

            return context.Response.WriteAsync(exceptionResult);
        }
    }
}
