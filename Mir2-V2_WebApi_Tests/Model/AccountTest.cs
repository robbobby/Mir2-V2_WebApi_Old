using Mir2_v2_WebApi.Model;
using Xunit;
namespace Mir2_V2_WebApi_Tests.Model {
    public class AccountTest {
        private Account account = new();

        [Fact]
        public void AccountHasRequiredPropertiesForDatabase() {
            Assert.Contains(typeof(IDynamoDbEntry), typeof(Account).GetInterfaces());
        }
    }
}
