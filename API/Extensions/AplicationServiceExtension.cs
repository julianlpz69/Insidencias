

using Aplicacion.UnitOfWork;
using Dominio.Intefaces;

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


        public static void AddAppServices(this IServiceCollection Services){

            Services.AddScoped<IUnitOfWork, UnitOfWork>();

        }

    public static void ConfigureRateliniting(this IServiceCollection services){

        }


    }
}