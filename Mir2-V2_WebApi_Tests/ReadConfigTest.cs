using System.Collections.Generic;
using System.Linq;
using Mir2_v2_WebApi.Helpers;
using Xunit;
using Xunit.Abstractions;

namespace Mir2_V2_WebApi_Tests {
    public class ReadConfigTest {
        private readonly ITestOutputHelper writer;
        public ReadConfigTest(ITestOutputHelper _writer) {
            this.writer = _writer;
        }

        [Fact]
        public void CanOpenFileAndReadWithPath() {
            Assert.True(ReadConfig.ReadFile().Length > 5);
        }

        [Fact]
        public void CanGetDatabaseJToken() {
            var jTokenString = ReadConfig.GetDatabaseConfigJToken().ToString();
            Assert.Contains("database", jTokenString);
            Assert.Contains("name", jTokenString);
            Assert.Contains("awsKeyFile", jTokenString);
            Assert.DoesNotContain("awsKeyFila", jTokenString);
        }
        
        [Fact] // Copy the credentials in the json file to the tests
        public void CanGetDatabaseAndAwsKeyPath() {
            var x = ReadConfig.GetDatabaseInfo();
            Assert.Equal("Mir2-V2_TestDb", x[DatabaseSettings.Name]);
            Assert.Equal("/Users/rob/AmazonAccess/DynamoDbAccess.json", x[DatabaseSettings.AwsKeyFilePath]);
            writer.WriteLine(x[DatabaseSettings.AwsKeyFilePath]);
        }

        [Fact]
        public void IsReadingJsonFile() {
        var databaseInfo = ReadConfig.GetDatabaseInfo();
        Assert.True(databaseInfo.Count > 0);
        writer.WriteLine(databaseInfo[DatabaseSettings.Name]);
             
        }
        
        [Fact]
        public void CanReadDatabaseNameFromConfigFile() {
        var databaseInfo = ReadConfig.GetDatabaseInfo();
        Assert.Equal("Mir2-V2_TestDb", databaseInfo[DatabaseSettings.Name]);
        writer.WriteLine(databaseInfo.Count.ToString());
        }

        [Fact]
        public void CanGetAwsAccessKeys() { // Test may fail if SecretKey doesn't have to contain at least 3 backslashes
            Dictionary<DatabaseSettings, string> x = ReadConfig.GetDatabaseInfo();
            var y = ReadConfig.GetAwsAccessKey(x[DatabaseSettings.AwsKeyFilePath]);
            writer.WriteLine(y[DatabaseLogin.AccessKey]);
            writer.WriteLine(y[DatabaseLogin.SecretKey]);
            
            Assert.True(y[DatabaseLogin.AccessKey].Length > 15);
            
            int keyCount = y[DatabaseLogin.SecretKey].Count(_letter => _letter == '/');
            Assert.True(keyCount >= 3);
        }

    }
}
