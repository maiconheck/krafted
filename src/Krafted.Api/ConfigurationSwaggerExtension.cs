using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Krafted.Api
{
    public static class ConfigurationSwaggerExtension
    {
        public static void ConfigureSwaggerDefault(this IServiceCollection services, string nameApi, string version)
        {
            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc(version, new Info { Title = nameApi, Version = version });
            });
        }

        public static void UseSwaggerDefault(this IApplicationBuilder app, string nameApi, string version)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint($"/swagger/{version}/swagger.json", $"{nameApi} {version}");
            });
        }
    }
}
