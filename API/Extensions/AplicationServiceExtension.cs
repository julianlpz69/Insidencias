

namespace API.Extensions
{
    public static class AplicationServiceExtension
    {
        
        public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>{

            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
        });

    }
}