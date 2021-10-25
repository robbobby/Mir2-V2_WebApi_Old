using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
using Mir2_v2_WebApi.Helpers;
namespace Mir2_v2_WebApi.DynamoDb {
    public class DynamoHelper {
        
        public static string DatabaseName { get; private set; }
        
        public static IAmazonDynamoDB GetClient() {
            var databaseInfo = DatabaseConfigReader.GetDatabaseConnectionDetails();
            DatabaseName = databaseInfo[DatabaseSettings.Name];
            return new AmazonDynamoDBClient(DynamoCredentials(databaseInfo[DatabaseSettings.AwsKeyFilePath]), GetDynamoConfig());
        }
        
        private static AmazonDynamoDBConfig GetDynamoConfig() {
            RegionEndpoint regionEndpoint = RegionEndpoint.EUWest1;
            return new AmazonDynamoDBConfig() {
                RegionEndpoint = regionEndpoint
            };
        }
        
        private static AWSCredentials DynamoCredentials(string _filePath) {
            var loginDetails = DatabaseConfigReader.GetAwsAccessKey(_filePath);
            return new BasicAWSCredentials(loginDetails[DatabaseLogin.AccessKey], 
                loginDetails[DatabaseLogin.SecretKey]);
        }
    }
}
