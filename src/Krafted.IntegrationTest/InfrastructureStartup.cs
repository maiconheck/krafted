using System.Diagnostics.CodeAnalysis;
using Krafted.Configuration;
using Krafted.Data.Connection;
using Krafted.Data.SqlBuilder;
using Krafted.Data.SqlServer.Connection;
using Krafted.Data.SqlServer.SqlBuilder;
using Krafted.IntegrationTest.Migration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Krafted.IntegrationTest
{
    /// <summary>
    /// Represents the initialization class used for integration testing from the Repositories.
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class InfrastructureStartup
    {
        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc()
            .AddJsonOptions(opt =>
            {
                // These should be the defaults, but we can be explicit:
                opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                opt.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
            })
            .AddDataAnnotationsLocalization();

            services.AddScoped<IConnectionProvider, SqlServerConnectionProvider>(
                _ => new SqlServerConnectionProvider(Config.Instance().GetConnectionString()));

            services.AddScoped<ISqlBuilderFactory, BultinSqlBuilderFactory>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting enviroment.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseRequestLocalization(new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture("pt-BR", "pt-BR") })
               .UseCors(policy => policy
               .AllowAnyOrigin()
               .AllowAnyHeader()
               .AllowAnyMethod())
               .UseMvcWithDefaultRoute()
               .UseMigration(Config.Instance().GetConnectionString("SqlServerConnection"));
        }
    }
}