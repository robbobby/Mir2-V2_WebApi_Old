using Amazon.DynamoDBv2.DataModel;
namespace Mir2_v2_WebApi.Model {
    public class Account {
        [DynamoDBHashKey]
        public int AccountId { get; set; }        
    }
}
