using System;
using Amazon;
using Amazon.DynamoDBv2;
using Amazon.Runtime;
namespace Mir2_v2_WebApi.Secret {
    public class DynamoHelper {

        public static IAmazonDynamoDB GetClient() {
            return new AmazonDynamoDBClient(DynamoCredentials(), GetDynamoConfig());
        }
        
        private static AmazonDynamoDBConfig GetDynamoConfig() {
            RegionEndpoint regionEndpoint = RegionEndpoint.EUWest1;
            return new AmazonDynamoDBConfig() {
                RegionEndpoint = regionEndpoint
            };
        }
        
        private static AWSCredentials DynamoCredentials() {
            return new BasicAWSCredentials(DynamoDbSecret.GetAccessKey(), DynamoDbSecret.GetSecretKey());
        }
    }
}
