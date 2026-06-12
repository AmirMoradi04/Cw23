using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace WebApiPresention
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class IPAuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private static readonly byte[] address = 
        {
            8 ,1 ,198 ,170 ,172
        };
        
        public IPAuthenticationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            var ip = httpContext.Connection.RemoteIpAddress;

            if(ip is not null && ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
            {
                var firstNumberIp = ip.GetAddressBytes()[0];

                if (address.Contains(firstNumberIp))
                {
                    httpContext.Response.StatusCode = 403;
                    await httpContext.Response.WriteAsJsonAsync(new
                    {
                        Error = "Blocked : U.S.A IP is Detected"
                    });
                    return;
                }
            }
            await _next(httpContext);
           
            

            //if (httpContext.Request.Method != HttpMethod.Get.Method)
            //{
            //    var remoteIp = httpContext.Connection.RemoteIpAddress;


            //    var bytes = remoteIp.GetAddressBytes();
            //    var badIp = true;
            //    foreach (var address in _safelist)
            //    {
            //        if (address.SequenceEqual(bytes))
            //        {
            //            badIp = false;
            //            break;
            //        }
            //    }
                 

            }
        }

        // Extension method used to add the middleware to the HTTP request pipeline.
        public static class IPAuthenticationMiddlewareExtensions
        {
            public static IApplicationBuilder UseIPAuthenticationMiddleware(this IApplicationBuilder builder)
            {
                return builder.UseMiddleware<IPAuthenticationMiddleware>();
            }
        }
    }
