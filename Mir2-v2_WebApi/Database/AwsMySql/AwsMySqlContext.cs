using Microsoft.EntityFrameworkCore;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.AwsMySql {
    public class AwsMySqlContext : DbContext {
        public virtual DbSet<Account> Accounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder _optionsBuilder) {
            if (_optionsBuilder.IsConfigured)
                return;

            var databaseName = "";
            var serverName = "";
            var username = "";
            var password = "";
            _optionsBuilder.UseSqlServer($"Server={serverName}; Database={databaseName}; Username={username}; Password={password}");
            base.OnConfiguring(_optionsBuilder);
        }
    }
}
