using Microsoft.EntityFrameworkCore;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.Broker {
    public sealed class AccountBroker : DbContext {
        public AccountBroker(DbContextOptions<AccountBroker> _options) : base(_options) {
            this.Database.Migrate();
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Character> Characters { get; set; }
        
    }
}