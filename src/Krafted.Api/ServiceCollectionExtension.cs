using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Krafted.Api
{
    /// <summary>
    /// Provides extension methods to <see cref="IServiceCollection"/>.
    /// </summary>
    internal static class ServiceCollectionExtension
    {
        /// <summary>
        /// Configures the MVC default.
        /// </summary>
        /// <param name="services">The services.</param>
        public static void ConfigureMvcDefault(this IServiceCollection services)
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
        }
    }
}