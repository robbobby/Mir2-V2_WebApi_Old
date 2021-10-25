using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.Model {
    public class Character : IDynamoDbEntry {

        public string Id { get; set; }
        public DynamoEntryTypeId EntryTypeId { get; private set; } = DynamoEntryTypeId.Character;
    }
}
