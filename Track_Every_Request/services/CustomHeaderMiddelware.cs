namespace Track_Every_Request.services
{
    public class CustomHeaderMiddelware
    {
        private readonly RequestDelegate _next;

        public CustomHeaderMiddelware(RequestDelegate requestDelegate)
        {
            _next = requestDelegate;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            context.Request.Headers.TryGetValue("x-correlation-Id", out var Id);

            context.Items["x-correlation-Id"] = Id;

            await _next(context);
        }
    }
}
