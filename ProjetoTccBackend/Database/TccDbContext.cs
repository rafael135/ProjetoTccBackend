using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Pomelo.EntityFrameworkCore.MySql;

using ProjetoTccBackend.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ProjetoTccBackend.Database
{
    public class TccDbContext : IdentityDbContext<User>
    {
        private IConfiguration _configuration;

        public TccDbContext(IConfiguration configuration) : base()
        {
            this._configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(
                this._configuration.GetConnectionString("mariaDB"),
                ServerVersion.AutoDetect(this._configuration.GetConnectionString("mariaDB"))

            );
        }

        
    }
}
