using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.Database.DynamoDb {
    public class DynamoDbAccountRepository : IDataAccess {
        private readonly IAmazonDynamoDB amazonDynamoDb;
        private readonly DynamoDBOperationConfig dbConfig = DynamoHelper.DynamoDbOperationConfig;
        private readonly IDynamoDBContext dbContext;

        public DynamoDbAccountRepository(IDynamoDBContext _dbContext, IAmazonDynamoDB _amazonDynamoDb) {
            dbContext = _dbContext;
            amazonDynamoDb = _amazonDynamoDb;
        }

        public async Task<IEnumerable<Account>> GetAllAccounts() {
            return await dbContext.QueryAsync<Account>("1").GetRemainingAsync();
        }

        public async Task<Account> GetAccount(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId) {
            return await dbContext.LoadAsync<Account>(dbConfig);
        }

        public async Task<Account> GetCharacter(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId) {
            return await dbContext.LoadAsync<Account>(_accountId);
        }

        public async Task<Account> PostAccount(Account _account) {
            await dbContext.SaveAsync(_account);
            return _account; // Alter this if going back into production
        }
        public async Task DeleteAccount(Account _account) {
            await dbContext.DeleteAsync(_account);
        }
    }
}
