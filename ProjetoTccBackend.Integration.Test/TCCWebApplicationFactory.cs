using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjetoTccBackend.Database;
using Testcontainers.MariaDb;

namespace ProjetoTccBackend.Integration.Test
{
    public class TCCWebApplicationFactory : WebApplicationFactory<ProjetoTccBackend>, IAsyncLifetime
    {
        private readonly MariaDbContainer _dbContainer;

        public TCCWebApplicationFactory()
        {
            // Configuration of the container
            _dbContainer = new MariaDbBuilder()
                .WithImage("mariadb:latest")
                .WithDatabase("projetotcc_test")
                .WithUsername("admin")
                .WithPassword("admin")
                .WithCleanUp(true)
                .Build();
        }

        // Initialize the container
        public async Task InitializeAsync()
        {
            await _dbContainer.StartAsync();
        }

        // stops and dispose the containers
        public async Task DisposeAsync()
        {
            await _dbContainer.StopAsync();
            await _dbContainer.DisposeAsync();
        }

        // Configures the WebHost to use the container ConnectionString
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureAppConfiguration((context, config) =>
            {
                var connectionString = _dbContainer.GetConnectionString();

                var settings = new Dictionary<string, string>
                {
                    { "ConnectionStrings:DefaultConnection", connectionString }
                };

                config.AddInMemoryCollection(settings); // override the connectionString
            });

            builder.ConfigureServices(services =>
            {
                
                var serviceProvider = services.BuildServiceProvider();
                using (var scope = serviceProvider.CreateScope())
                {
                    var db = scope.ServiceProvider.GetRequiredService<TccDbContext>();
                    db.Database.EnsureDeleted(); // Ensures the database is empty
                    db.Database.Migrate(); // Apply migrations
                }
            });
        }
    }
}
