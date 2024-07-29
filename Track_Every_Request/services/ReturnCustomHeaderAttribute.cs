using Microsoft.AspNetCore.Mvc.Filters;

namespace Track_Every_Request.services
{
    public class ReturnCustomHeaderAttribute : ResultFilterAttribute
    {
        public override void OnResultExecuting(ResultExecutingContext context)
        {
            context.HttpContext.Request.Headers.TryGetValue("x-correlation-Id", out var Id);

            context.HttpContext.Response.Headers.Append("x-correlation-Id", Id.ToString());

            base.OnResultExecuting(context);

        }
    }
}
