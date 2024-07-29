using Microsoft.AspNetCore.Mvc.Filters;

namespace Track_Every_Request.services
{
    public class CustomHeaderAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("x-correlation-Id", out var Id);

            context.HttpContext.Items["x-correlation-Id"] = Id;
        }
    }
}
