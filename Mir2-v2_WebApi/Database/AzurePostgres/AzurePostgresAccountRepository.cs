using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Mir2_v2_WebApi.Broker;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;

namespace Mir2_v2_WebApi.Database.AzurePostgres {
    public class AzurePostgresAccountRepository : IDataAccess {

        private readonly AccountBroker context;
        public AzurePostgresAccountRepository(AccountBroker _context) {
            context = _context;
        }
        public async Task<IEnumerable<Account>> GetAllAccounts() {
            return await context.Accounts.ToListAsync();
        }
        public async Task<Account> GetAccount(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId = "1") {
            return await context.Accounts.FindAsync(_accountId);
        }
        public async Task<Account> PostAccount(Account _account) {
            EntityEntry<Account> x = await context.Accounts.AddAsync(_account);
            return x.Entity;
        }
        
        public Task DeleteAccount(Account _account) {
            /* context.Entry(_account).State = EntityState.Deleted
                could be a way of getting back to result of the delete state */
            context.Remove(_account);

            return null;
        }
        public Task<Account> GetCharacter(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId) {
            throw new System.NotImplementedException();
        }
    }
}
