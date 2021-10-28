using System.Collections.Generic;
using System.Threading.Tasks;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.Database {
    public interface IDataAccess {
        Task<IEnumerable<Account>> GetAllAccounts();
        public Task<Account> GetAccount(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId = "1");
        public Task<Account> PostAccount(Account _account);
        Task DeleteAccount(Account _account);
        Task<Account> GetCharacter(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId);
    }
}
