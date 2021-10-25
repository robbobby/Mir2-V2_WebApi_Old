using System.Collections.Generic;
using System.Linq;
using Mir2_v2_WebApi.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Mir2_V2_WebApi_Tests {
    public class DatabaseConfigReaderTest {
        private readonly ITestOutputHelper writer;
        public DatabaseConfigReaderTest(ITestOutputHelper _writer) {
            this.writer = _writer;
        }

        [Fact]
        public void CanOpenFileAndReadWithPath() {
            Assert.True(DatabaseConfigReader.ReadFile().Length > 5);
        }

        [Fact]
        public void CanGetDatabaseJToken() {
            var jTokenString = DatabaseConfigReader.GetDatabaseConfigJToken().ToString();
            Assert.Contains("database", jTokenString);
            Assert.Contains("name", jTokenString);
            Assert.Contains("awsKeyFile", jTokenString);
            Assert.DoesNotContain("awsKeyFila", jTokenString);
        }
        
        [Fact] // Copy the credentials in the json file to the tests
        public void CanGetDatabaseAndAwsKeyPath() {
            var databaseInfo = DatabaseConfigReader.GetDatabaseConnectionDetails();
            Assert.Equal("Mir2-V2_TestDb", databaseInfo[DatabaseSettings.Name]);
            Assert.Equal("/Users/rob/AmazonAccess/DynamoDbAccess.json", databaseInfo[DatabaseSettings.AwsKeyFilePath]);
            writer.WriteLine(databaseInfo[DatabaseSettings.AwsKeyFilePath]);
        }

        [Fact]
        public void IsReadingJsonFile() {
        var databaseInfo = DatabaseConfigReader.GetDatabaseConnectionDetails();
        Assert.True(databaseInfo.Count > 0);
        writer.WriteLine(databaseInfo[DatabaseSettings.Name]);
             
        }
        
        [Fact]
        public void CanReadDatabaseNameFromConfigFile() {
        var databaseInfo = DatabaseConfigReader.GetDatabaseConnectionDetails();
        Assert.Equal("Mir2-V2_TestDb", databaseInfo[DatabaseSettings.Name]);
        writer.WriteLine(databaseInfo.Count.ToString());
        }

        [Fact]
        public void CanGetAwsAccessKeys() { // Test will fail if SecretKey doesn't have to contain at least 3 backslashes
            Dictionary<DatabaseSettings, string> databaseConnectionDetails = DatabaseConfigReader.GetDatabaseConnectionDetails();
            var awsAccessKeyDetails = DatabaseConfigReader.GetAwsAccessKey(databaseConnectionDetails[DatabaseSettings.AwsKeyFilePath]);
            writer.WriteLine(awsAccessKeyDetails[DatabaseLogin.AccessKey]);
            writer.WriteLine(awsAccessKeyDetails[DatabaseLogin.SecretKey]);
            
            Assert.True(awsAccessKeyDetails[DatabaseLogin.AccessKey].Length > 15);
            
            int keyCount = awsAccessKeyDetails[DatabaseLogin.SecretKey].Count(_letter => _letter == '/');
            Assert.True(keyCount >= 3);
        }

    }
}
