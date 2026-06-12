using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace WebApiPresention
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExampleMiddleware
    {
        private readonly RequestDelegate _next;
        private Dictionary<string ,List<DateTime>> _inputs = new();

        public ExampleMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var ip = httpContext.Connection.RemoteIpAddress?.ToString();
            if (!_inputs.ContainsKey(ip))
            {
                _inputs[ip] = new List<DateTime>();
            }
            else
            {
                _inputs[ip].Add(DateTime.UtcNow);
            }
            
            //var time = ip.ad
            
            
            var task = _next(httpContext);

            if (await Task.WhenAny(task, Task.Delay(1000)) != task)
            {
                httpContext.Response.StatusCode = 403;
                await httpContext.Response.WriteAsync("Access Denied");
                throw new Exception("timeout!");
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExampleMiddlewareExtensions
    {
        public static IApplicationBuilder UseExampleMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExampleMiddleware>();
        }
    }
}
