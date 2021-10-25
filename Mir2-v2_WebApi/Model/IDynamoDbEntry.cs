using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.Model {
    public interface IDynamoDbEntry {
        string Id { get; set; }
        DynamoEntryTypeId EntryTypeId { get; }
    }
}
