using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Krafted.Api
{
    public static class ConfigurationMvcExtension
    {
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

			services.AddResponseCompression();
            services.ConfigureSwaggerDefault("Krafted API", "v1");
        }
    }
}
