using CW21.Presentation.Service.Exceptions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using WebApiPresention.Utils;

namespace WebApiPresention
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (NotFoundException ex)
            {
                await HandleException(httpContext, ex, 404);
            }
            catch (BadRequestException ex)
            {
                await HandleException(httpContext, ex, 400);
            }
            catch (Exception ex)
            {
                await HandleException(httpContext, ex, 500);
            }
        }

        private async static Task HandleException(HttpContext httpContext, Exception exception, int statusCode)
        {
            httpContext.Response.ContentType = "application/json";
            httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
            string message;
            if(statusCode == 500)
            {
                message = "Server Dochare Moshkel Shode Ast :)";
            }
            else
            {
                message = exception.Message;
            }
            var response = Result.Failure(
                
               message: message,
               statusCode: statusCode
            );

            var option = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, option);
            await httpContext.Response.WriteAsync(json);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
