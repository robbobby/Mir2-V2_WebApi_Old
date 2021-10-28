using Mir2_v2_WebApi.Model;
using Xunit;
namespace Mir2_V2_WebApi_Tests.Model {
    public class ItemTest {
        private Item item = new();

        [Fact]
        public void ItemRequiredPropertiesForDatabase() {
            Assert.Contains(typeof(IDynamoDbEntry), typeof(Item).GetInterfaces());
        }
    }
}
