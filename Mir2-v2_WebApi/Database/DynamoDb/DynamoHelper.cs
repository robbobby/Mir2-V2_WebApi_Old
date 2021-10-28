using Amazon;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Amazon.Runtime;
using Mir2_v2_WebApi.Helpers;
namespace Mir2_v2_WebApi.DynamoDb {
    public class DynamoHelper {

        public static DynamoDBOperationConfig DynamoDbOperationConfig { get; private set; }


        public static IAmazonDynamoDB GetClient() {
            var databaseInfo = DynamoDatabaseConfigReader.GetDatabaseConnectionDetails();
            DynamoDbOperationConfig = new DynamoDBOperationConfig {
                // OverrideTableName = databaseInfo[DatabaseSettings.Name]
                OverrideTableName = "Mir2-V2_TestDb"
            };

            return new AmazonDynamoDBClient(DynamoCredentials(databaseInfo[DatabaseSettings.AwsKeyFilePath]), GetDynamoConfig());
        }

        private static AmazonDynamoDBConfig GetDynamoConfig() {
            RegionEndpoint regionEndpoint = RegionEndpoint.EUWest1;
            return new AmazonDynamoDBConfig {
                RegionEndpoint = regionEndpoint
            };
        }

        private static AWSCredentials DynamoCredentials(string _filePath) {
            var loginDetails = DynamoDatabaseConfigReader.GetAwsAccessKey(_filePath);
            return new BasicAWSCredentials(loginDetails[DatabaseLogin.AccessKey],
                loginDetails[DatabaseLogin.SecretKey]);
        }
    }
}
