using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Mvc;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;
namespace Mir2_v2_WebApi.Controllers {

    [ApiController]
    [Route("[controller]")]
    public class CharacterController {
        private readonly DynamoDBOperationConfig dbConfig = DynamoHelper.DynamoDbOperationConfig;
        private readonly IDynamoDBContext dbContext;

        public CharacterController(IDynamoDBContext _dbContext) {
            dbContext = _dbContext;
        }

        [HttpGet]
        public async Task<IEnumerable<Character>> GetAccountCharacters(int _accountId = 1) {
            return await dbContext.QueryAsync<Character>(_accountId, dbConfig)
                .GetRemainingAsync();

        }
    }
}
