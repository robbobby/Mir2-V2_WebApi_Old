using System;
using System.Threading.Tasks;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Mir2_v2_WebApi.Controllers;
using Mir2_v2_WebApi.Database.DynamoDb;
using Mir2_v2_WebApi.DynamoDb;
using Mir2_v2_WebApi.Model;
using Xunit;
using Xunit.Abstractions;
namespace Mir2_V2_WebApi_Tests.Controllers {
    public class AccountControllerTest {
        private static AmazonDynamoDBClient amazonDynamoDbClient;
        private readonly ITestOutputHelper writer;
        private readonly AccountController accountController;
        private readonly Account testAccount = new() {
            Id = "testIsd",
            Password = "somePassword",
            Email = "testemail@email.com",
            FirstName = "test",
            LastName = "user"
        };

        public AccountControllerTest(ITestOutputHelper _writer) {
            writer = _writer;
            amazonDynamoDbClient = new AmazonDynamoDBClient();
            accountController =
                new AccountController(new DynamoDbAccountRepository(new DynamoDBContext(amazonDynamoDbClient), amazonDynamoDbClient));
        }

        [Fact] public void CanCreateAccount() {
            accountController.PostAccount(testAccount);
            Account x = accountController.GetAccount(testAccount.EntryTypeId, testAccount.Id).Result;
            Assert.Equal(testAccount.Email, x.Email);
        }

        [Fact]
        public void CanDeleteAccount() {
            accountController.DeleteAccount(testAccount);
            // Assert.Null(accountController.GetAccount(testAccount.Id).Exception);
            AggregateException aggregateException = accountController.GetAccount(testAccount.EntryTypeId, testAccount.Id).Exception;
            if (aggregateException != null) writer.WriteLine(aggregateException.Message);
        }


        [Fact]
        public void TestCanPostAndGetAccountToDb() {
            Task accountFromApi = accountController.PostAccount(testAccount);
            writer.WriteLine(accountFromApi.Status.ToString());
        }
    }
}
