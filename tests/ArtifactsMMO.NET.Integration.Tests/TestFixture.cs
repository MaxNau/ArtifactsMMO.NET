using ArtifactsMMO.NET.DependencyInjection.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ArtifactsMMO.NET.Integration.Tests
{
    public class TestFixture : IDisposable
    {
        private bool _disposedValue;
        public IServiceProvider ServiceProvider { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public TestFixture()
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.local.json", optional: true)
                .Build();

            var services = new ServiceCollection();

            services.AddSingleton(Configuration);
            services.AddArtifactsMMOClient(Configuration["AppSettings:ApiKey"]);

            ServiceProvider = services.BuildServiceProvider();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposedValue)
            {
                if (disposing)
                {
                    if (ServiceProvider is IDisposable disposable)
                    {
                        disposable.Dispose();
                    }
                }

                _disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
