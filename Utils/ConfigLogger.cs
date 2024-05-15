using Serilog;
using Serilog.Events;

namespace Nike_clone_Backend;

public class ConfigLogger
{
    public static object ConfigureLogger()
    {
        return new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.File(path: "logs/nike_clone_debug.log", rollingInterval: RollingInterval.Day)
            .WriteTo.File(path: "logs/nike_clone_info.log", restrictedToMinimumLevel: LogEventLevel.Information, rollingInterval: RollingInterval.Day)
            .WriteTo.File(path: "logs/nike_clone_error.log", restrictedToMinimumLevel: LogEventLevel.Error, rollingInterval: RollingInterval.Day)
            .WriteTo.Console(restrictedToMinimumLevel: LogEventLevel.Warning)
            .CreateLogger();
    }

}
