using System.ComponentModel.DataAnnotations;
using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.Model {
    public class Character : IDynamoDbEntry {
        [Key]
        public string Id { get; set; }
        public Account Account { get; set; }
        public string Name { get; set; }
        public DynamoEntryTypeId EntryTypeId { get; private set; } = DynamoEntryTypeId.Character;
        public CharacterClass CharacterClass { get; set; }
    }
}
