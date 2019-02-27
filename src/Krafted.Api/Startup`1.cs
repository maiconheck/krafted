using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Localization;
using SharedKernel.Application.Commands.Result;
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
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.ConfigureMvcDefault();
            services.AddScoped<ICommandResultFactory, DefaultCommandResultFactory>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRequestLocalization(new RequestLocalizationOptions { DefaultRequestCulture = new RequestCulture("pt-BR", "pt-BR") });
            app.UseResponseCaching();
            app.UseResponseCompression();

            app.UseCors(policy => policy
                .AllowAnyOrigin()
                .AllowAnyHeader()
                .AllowAnyMethod());

            app.UseMvcWithDefaultRoute();
        }
    }
}
