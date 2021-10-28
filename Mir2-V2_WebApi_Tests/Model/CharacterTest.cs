using Mir2_v2_WebApi.Model;
using Xunit;
namespace Mir2_V2_WebApi_Tests.Model {
    public class CharacterTest {
        private Character character = new();

        [Fact]
        public void CharacterHasRequiredPropertiesForDatabase() {
            Assert.Contains(typeof(IDynamoDbEntry), typeof(Character).GetInterfaces());
        }
    }
}
