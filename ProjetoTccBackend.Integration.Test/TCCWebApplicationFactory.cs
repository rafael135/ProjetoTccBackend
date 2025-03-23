using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using ProjetoTccBackend.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Testcontainers.MariaDb;

namespace ProjetoTccBackend.Integration.Test
{
    public class TCCWebApplicationFactory : WebApplicationFactory<ProjetoTccBackend>, IAsyncLifetime
    {
        public TccDbContext Context { get; private set; }

        private readonly MariaDbContainer _dbContainer;

        public TCCWebApplicationFactory()
        {
            _dbContainer = new MariaDbBuilder()
                .WithImage("mariadb:latest")
                .WithDatabase("projetotcc")
                .WithUsername("admin")
                .WithPassword("admin")
                .WithPortBinding(2642, 3306)
                .WithCleanUp(true)
                .Build();
        }

        public async Task InitializeAsync()
        {
            await this._dbContainer.StartAsync();
        }

        public async Task DisposeAsync()
        {
            await this._dbContainer.DisposeAsync();
        }

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);

            builder.ConfigureServices(services =>
            {
                builder.ConfigureLogging(logging =>
                {
                    logging.SetMinimumLevel(LogLevel.Debug);
                });

                // Removes existent dbContextOptions
                var existentDbOptions = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<TccDbContext>));

                if(existentDbOptions is not null)
                {
                    services.Remove(existentDbOptions);
                }

                // Adds test dbContext
                services.AddDbContext<TccDbContext>(options =>
                {
                    options.UseMySql(
                        this._dbContainer.GetConnectionString(),
                        ServerVersion.AutoDetect(this._dbContainer.GetConnectionString())
                    );
                });


                var sp = services.BuildServiceProvider();
                var scope = sp.CreateScope();

                var scopedServices = scope.ServiceProvider;
                var db = scopedServices.GetRequiredService<TccDbContext>();

                // Ensures the database is cleaned for the tests
                db.Database.EnsureDeleted();
                db.Database.Migrate();
                db.Database.EnsureCreated();

                this.Context = db;

            });
        }
    }
}
