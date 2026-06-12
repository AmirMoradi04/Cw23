using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Net;
using System.Threading.Tasks;

namespace WebApiPresention
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class SendProgramToSiteMiddleware
    {
        private readonly RequestDelegate _next;
        private const string target = "https://79.127.127.35";
        private static readonly byte[] address =
        {
            192
        };

        public SendProgramToSiteMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var ip = httpContext.Connection.RemoteIpAddress;

            if (ip is not null && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                var firstNumberIp = ip.GetAddressBytes()[0];

                if (address.Contains(firstNumberIp))
                {
                    httpContext.Response.Redirect(target);
                }
                return;
            }
            await _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class SendProgramToSiteMiddlewareExtensions
    {
        public static IApplicationBuilder UseSendProgramToSiteMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<SendProgramToSiteMiddleware>();
        }
    }
}
