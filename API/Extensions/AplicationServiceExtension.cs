

using Aplicacion.UnitOfWork;
using AspNetCoreRateLimit;
using Dominio.Intefaces;
using Microsoft.AspNetCore.Mvc;

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

        public static void ConfigureRatelimiting(this IServiceCollection services)
            {
                services.AddMemoryCache();
                services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();
                services.AddInMemoryRateLimiting();
                services.Configure<IpRateLimitOptions>(options =>
                {
                    options.EnableEndpointRateLimiting = true;
                    options.StackBlockedRequests = false;
                    options.HttpStatusCode = 429;
                    options.RealIpHeader = "X-Real-IP";
                    options.GeneralRules = new List<RateLimitRule>
                    {
                        new RateLimitRule
                        {
                            Endpoint = "*",
                            Period = "10s",
                            Limit = 2
                        }
                    };
                });
            }


        public static void ConfigureApiVersion(this IServiceCollection services){

            services.AddApiVersioning(options =>{

                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.AssumeDefaultVersionWhenUnspecified = true;

            });
        }


    }
}