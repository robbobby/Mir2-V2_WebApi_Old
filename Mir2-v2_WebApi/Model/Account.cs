using System.ComponentModel.DataAnnotations;
using Amazon.DynamoDBv2.DataModel;
using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.Model {
    public class Account : IDynamoDbEntry {

        [Key]
        public string Id { get; set; }
        public DynamoEntryTypeId EntryTypeId { get; private set; } = DynamoEntryTypeId.Account;
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
