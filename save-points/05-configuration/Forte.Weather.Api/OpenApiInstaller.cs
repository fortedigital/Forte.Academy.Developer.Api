
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.IO;
using System.Reflection;

namespace Forte.Weather.Api;
public static class OpenApiInstaller
{
    public static void AddOpenApi(this IServiceCollection services, IConfiguration configuration)
    {
        var title = configuration.GetSection("OpenApi")["Title"];
        var xmlDocumentation = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
        var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlDocumentation);        

        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new() 
            { 
                Title = title, 
                Version = "v1",
                Description = "Forte Academy building weather api"
            });

            options.IncludeXmlComments(xmlPath);
            
        });
    }

    public static void UseOpenApi(this IApplicationBuilder app)
    {
        app.UseStaticFiles();
        app.UseSwagger(options => options.RouteTemplate = "docs/{documentName}/docs.json");
        app.UseSwaggerUI(options =>
        {
            options.RoutePrefix = "docs";
            options.DocumentTitle = "Weather api";
            options.InjectStylesheet("/swagger-ui/custom.css");
            options.SwaggerEndpoint("/docs/v1/docs.json", "Forte.Weather.Api v1");
        });
    } 
}
