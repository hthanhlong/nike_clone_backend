using Serilog.Context;

namespace Nike_clone_Backend;

public class SerilogMiddleware
{
    private readonly RequestDelegate _next;

    public SerilogMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        // Push the TraceIdentifier into the log context so that it can be included in all logs created during this request
        using (LogContext.PushProperty("TraceId", context.TraceIdentifier))
        {
            await _next(context);
        }
    }
}
