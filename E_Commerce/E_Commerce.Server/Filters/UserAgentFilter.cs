using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace E_Commerce.Server.Filters;

public class UserAgentFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        var userAgent = context.HttpContext.Request.Headers["User-Agent"].ToString();
        if (userAgent.Contains("Mozilla", StringComparison.OrdinalIgnoreCase))
        {
            context.Result = new ContentResult
            {
                StatusCode = 0,
                Content = "Access denied for Swagger requests.",
            };
        }
    }
}

