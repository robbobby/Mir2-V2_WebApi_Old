using Amazon.DynamoDBv2.DataModel;
using Amazon.DynamoDBv2.Model;
using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.Model {
    public class Account : IDynamoDbEntry {
        public string Id { get; set; }
        
        [DynamoDBHashKey]
        public DynamoEntryTypeId EntryTypeId { get; private set; } = DynamoEntryTypeId.Item;
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
