public class TimeMiddleware
{
    readonly RequestDelegate next;

    public TimeMiddleware(RequestDelegate nextRequest)
    {
        next = nextRequest;
    }

    public async Task Invoke(HttpContext context)
    {

        if (context.Request.Query.Any(x => x.Key == "time"))
        {
            await context.Response.WriteAsync(DateTime.Now.ToShortTimeString());
        }
        await next(context);
    }
}

public static class TimeMiddlewareExtension
{
    public static IApplicationBuilder UseTimeMiddleware(this IApplicationBuilder build)
    {
        return build.UseMiddleware<TimeMiddleware>();
    }
}
