using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mir2_v2_WebApi.Database;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class AccountController {

        private readonly IDataAccess accountDataAccess;


        public AccountController(IDataAccess _accountDataAccess) {
            accountDataAccess = _accountDataAccess;
        }

        [HttpGet("[action]")]
        public async Task<IEnumerable<Account>> GetAllAccounts(string _accountId = "1") {
            return await accountDataAccess.GetAllAccounts();
        }


        [HttpGet("[action]")]
        public async Task<Account> GetAccount(DynamoEntryTypeId _testAccountEntryTypeId, string _accountId = "1") {
            return await accountDataAccess.GetAccount(_testAccountEntryTypeId, _accountId);
        }

        [HttpGet("[action]")]
        public async Task<Account> GetCharacter() {
            return await accountDataAccess.GetAccount(DynamoEntryTypeId.Account);
        }


        [HttpPost("[action]")]
        public async Task PostAccount(Account _account) {
            await accountDataAccess.PostAccount(_account);
        }

        [HttpPost("[action]")]
        public async Task DeleteAccount(Account _account) {
            await accountDataAccess.DeleteAccount(_account);
        }
    }
}
