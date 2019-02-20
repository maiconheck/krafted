using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.Commands.Result;
using Krafted.Infrastructure.Connections.SqlServer;
using SharedKernel.Application.Commands.Result.Default;

namespace Krafted.Api
{
    public abstract class Startup<TStartup>
    {
        public IConfiguration Configuration { get; }

        protected Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureSqlServerConnectionProvider<SqlServerConnectionProvider>(Configuration.GetSection("ConnectionStrings"));
            services.AddScoped<ICommandResultFactory, DefaultCommandResultFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(policy => policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseMvcWithDefaultRoute();
            app.UseResponseCompression();

            app.Run(async (context) =>
            {
                context.Response.ContentType = "text/plain; charset=utf-8";
            });
        }
    }
}
