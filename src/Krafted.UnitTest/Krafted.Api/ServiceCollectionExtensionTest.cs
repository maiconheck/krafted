using Krafted.Api;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using NSubstitute;
using Xunit;

namespace Krafted.UnitTest.Krafted.Api
{
    [Trait(nameof(UnitTest), nameof(Api))]
    public class ServiceCollectionExtensionTest
    {
        private readonly IServiceCollection _services;

        public ServiceCollectionExtensionTest() => _services = Substitute.For<IServiceCollection>();

        [Fact]
        public void CallConfigureMvcDefault_Services_ShouldBeReceived()
        {
            _services.AddMvcDefault();

            _services.Received().AddCors();

            _services.Received()
                .AddMvc()
                .AddJsonOptions(opt =>
                {
                    opt.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Utc;
                    opt.SerializerSettings.DateFormatHandling = DateFormatHandling.IsoDateFormat;
                    opt.SerializerSettings.DateParseHandling = DateParseHandling.DateTimeOffset;
                })
                .AddDataAnnotationsLocalization();
        }
    }
}