using Microsoft.AspNetCore.Cors.Infrastructure;
namespace Nike_clone_Backend.Utils;
public abstract class ConfigurationCors
{
    public static void CallBackMy(CorsOptions options)
    {
        if (options == null)
        {
            throw new ArgumentNullException(nameof(options));
        }
        options.AddPolicy("AllowAllOrigins",
            builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

    }
}