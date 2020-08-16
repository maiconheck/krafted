using System.IO;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;

namespace Krafted.UnitTest.Krafted.Configuration
{
    public class HostEnvironmentStub : IHostEnvironment
    {
        public HostEnvironmentStub(string environmentName)
        {
            EnvironmentName = environmentName;
            ContentRootPath = Directory.GetCurrentDirectory();
        }

        public string EnvironmentName { get; set; }

        public string ApplicationName { get; set; }

        public string ContentRootPath { get; set; }

        public IFileProvider ContentRootFileProvider { get; set; }
    }
}
