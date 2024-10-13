using Microsoft.OpenApi.Models;

namespace MasterNet.WebApi.Extensions;


public static class SwaggerServiceExtensions
{
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {

        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(x =>
        {
            var securityScheme = new OpenApiSecurityScheme
            {
                Description = "JWT Authorization Bearer Scheme",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.Http,
                Scheme = "Bearer",
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            };

            x.AddSecurityDefinition("Bearer", securityScheme);

            var securityRequirement = new OpenApiSecurityRequirement {
                {
                    securityScheme, new [] { "Bearer" }
                }
            };

            x.AddSecurityRequirement(securityRequirement);
        });

        return services;
    }

    public static IApplicationBuilder useSwaggerDocumentation(this IApplicationBuilder app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}