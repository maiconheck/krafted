using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SharedKernel.Application.Commands.Result;
using SharedKernel.Application.Commands.Result.Default;

namespace Krafted.Api
{
    /// <summary>
    /// Represents the Startup base class.
    /// </summary>
    /// <typeparam name="TStartup">The startup type.</typeparam>
    public abstract class Startup<TStartup>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup{TStartup}"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        protected Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Gets the configuration.
        /// </summary>
        /// <value>The configuration.</value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        /// </summary>
        /// <param name="services">The services.</param>
        public virtual void ConfigureServices(IServiceCollection services)
        {
            services.AddResponseCompression();
            services.AddResponseCaching();
            services.ConfigureMvcDefault();
            services.AddScoped<ICommandResultFactory, DefaultCommandResultFactory>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application builder.</param>
        /// <param name="env">The hosting enviroment.</param>
        public virtual void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

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