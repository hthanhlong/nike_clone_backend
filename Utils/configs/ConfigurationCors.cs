using Microsoft.AspNetCore.Cors.Infrastructure;
namespace Nike_clone_Backend.Utils.Configs;
public abstract class ConfigurationCors
{
    public static void CallBack(CorsOptions options)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        options.AddPolicy("AllowAllOrigins",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    }
}