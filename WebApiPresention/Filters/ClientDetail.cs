using Microsoft.AspNetCore.Mvc.Filters;

namespace WebApiPresention.Filters
{
    public class ClientDetail : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new NotImplementedException();
        }
        
        public void OnActionExecuting(ActionExecutingContext context)
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString();
            var userAgent = context.HttpContext.Request.Headers.UserAgent.ToString();

            Console.WriteLine(ip);
            Console.WriteLine(userAgent);
        }
    }
}
