using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class AccountController {
        private readonly IDynamoDBContext dbContext;
        private readonly DynamoDBOperationConfig dbConfig = new DynamoDBOperationConfig() {
            OverrideTableName = DynamoHelper.DatabaseName
        };

        public AccountController(IDynamoDBContext _dbContext) {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Account>> GetAccounts(int _accountId = 1) {
            return await dbContext.QueryAsync<Account>(_accountId, dbConfig)
                .GetRemainingAsync();
        }

        [HttpPost]
        public async Task PostAccount(int _accountId) {
            await dbContext.SaveAsync(new Account() {
                Id = _accountId.ToString()
            }, dbConfig);
        }
    }
}
