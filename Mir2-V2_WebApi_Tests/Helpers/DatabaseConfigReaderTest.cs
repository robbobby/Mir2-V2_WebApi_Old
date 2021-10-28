using System.Linq;
using Mir2_v2_WebApi.Helpers;
using Xunit;
using Xunit.Abstractions;
namespace Mir2_V2_WebApi_Tests {
    public class DatabaseConfigReaderTest {
        private readonly ITestOutputHelper writer;
        public DatabaseConfigReaderTest(ITestOutputHelper _writer) {
            writer = _writer;
        }

        [Fact]
        public void CanOpenFileAndReadWithPath() {
            Assert.True(DynamoDatabaseConfigReader.ReadFile().Length > 5);
        }

        [Fact]
        public void CanGetDatabaseJToken() {
            var jTokenString = DynamoDatabaseConfigReader.GetDatabaseConfigJToken().ToString();
            Assert.Contains("database", jTokenString);
            Assert.Contains("name", jTokenString);
            Assert.Contains("awsKeyFile", jTokenString);
            Assert.DoesNotContain("awsKeyFila", jTokenString);
        }

        [Fact] // Copy the credentials in the json file to the tests
        public void CanGetDatabaseAndAwsKeyPath() {
            var databaseInfo = DynamoDatabaseConfigReader.GetDatabaseConnectionDetails();
            Assert.Equal("Mir2-V2_TestDb", databaseInfo[DatabaseSettings.Name]);
            Assert.Equal("/Users/rob/AmazonAccess/DynamoDbAccess.json", databaseInfo[DatabaseSettings.AwsKeyFilePath]);
            writer.WriteLine(databaseInfo[DatabaseSettings.AwsKeyFilePath]);
        }

        [Fact]
        public void IsReadingJsonFile() {
            var databaseInfo = DynamoDatabaseConfigReader.GetDatabaseConnectionDetails();
            Assert.True(databaseInfo.Count > 0);
            writer.WriteLine(databaseInfo[DatabaseSettings.Name]);

        }

        [Fact]
        public void CanReadDatabaseNameFromConfigFile() {
            var databaseInfo = DynamoDatabaseConfigReader.GetDatabaseConnectionDetails();
            Assert.Equal("Mir2-V2_TestDb", databaseInfo[DatabaseSettings.Name]);
            writer.WriteLine(databaseInfo.Count.ToString());
        }

        [Fact]
        public void CanGetAwsAccessKeys() { // Test will fail if SecretKey doesn't have to contain at least 3 backslashes
            var databaseConnectionDetails = DynamoDatabaseConfigReader.GetDatabaseConnectionDetails();
            var awsAccessKeyDetails = DynamoDatabaseConfigReader.GetAwsAccessKey(databaseConnectionDetails[DatabaseSettings.AwsKeyFilePath]);

            Assert.True(awsAccessKeyDetails[DatabaseLogin.AccessKey].Length > 15);

            var keyCount = awsAccessKeyDetails[DatabaseLogin.SecretKey].Count(_letter => _letter == '/');
            Assert.True(keyCount >= 3);
        }
    }
}
