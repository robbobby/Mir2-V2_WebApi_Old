using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.Model {
    public class Item : IDynamoDbEntry {

        public string Id { get; set; }
        public DynamoEntryTypeId EntryTypeId { get; } = DynamoEntryTypeId.Item;
    }
}
