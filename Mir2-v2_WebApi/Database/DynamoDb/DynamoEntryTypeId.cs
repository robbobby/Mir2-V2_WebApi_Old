using System;
namespace Mir2_v2_WebApi.DynamoDb {
    [Flags]
    public enum DynamoEntryTypeId {
        Account = 1,
        Character = 2,
        Item = 3
    }
}
