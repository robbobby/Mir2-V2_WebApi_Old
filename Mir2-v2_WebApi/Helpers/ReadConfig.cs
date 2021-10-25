using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
namespace Mir2_v2_WebApi.Helpers {
    
    // TODO: Handle errors that may come from the correct data not been in the JSON
    
    public static class ReadConfig { 
        private static readonly string ConfigFilePath = Path.Combine(Environment.CurrentDirectory, "DevelopmentConfig.json");

        public static string ReadFile(string _path = "") {
            if (_path == "")
                _path = ConfigFilePath;
            return File.ReadAllText(_path);
        }

        public static Dictionary<DatabaseSettings, string> GetDatabaseInfo() {
            var databaseDetails = new Dictionary<DatabaseSettings, string>() {
                { DatabaseSettings.Name, "" },
                { DatabaseSettings.AwsKeyFilePath, "" }
            };
            if (!File.Exists(ConfigFilePath)) return databaseDetails;
            JToken databaseConfig = GetDatabaseConfigJToken(ConfigFilePath);
            var response = GetDatabaseConfigDetails(databaseConfig);

            databaseDetails[DatabaseSettings.Name] = response[0];
            databaseDetails[DatabaseSettings.AwsKeyFilePath] = response[1];
            return databaseDetails;
        }
        
        public static JToken GetDatabaseConfigJToken(string _path = "") {
            if (_path == "")
                _path = ConfigFilePath;
            JToken databaseConfig = JsonConvert.DeserializeObject<JToken>(ReadFile(_path));
            return databaseConfig;
        }

        private static List<string> GetDatabaseConfigDetails(JToken _databaseConfig) {
            var databaseName = "";
            var awsKeyFile = "";
            if (_databaseConfig != null) {
                databaseName = _databaseConfig["database"]?["name"]?.ToString();
                awsKeyFile = _databaseConfig["database"]?["awsKeyFile"]?.ToString();
            }
            return new List<string> {
                databaseName,
                awsKeyFile
            };
        }

        public static Dictionary<DatabaseLogin, string> GetAwsAccessKey(string _path) {
            JToken awsAccessCredentials = JsonConvert.DeserializeObject<JToken>(ReadFile(_path));
            var accessKey = "";
            var secretKey = "";

            if (awsAccessCredentials != null) {
                accessKey = awsAccessCredentials["DynamoDbAccess"]?["AccessKey"]?.ToString();
                secretKey = awsAccessCredentials["DynamoDbAccess"]?["SecretKey"]?.ToString();
            }

            return new Dictionary<DatabaseLogin, string>() {
                { DatabaseLogin.AccessKey, accessKey },
                { DatabaseLogin.SecretKey, secretKey }
            };
        }
    }



    public enum DatabaseSettings {
        Name,
        AwsKeyFilePath,
        RegionEndpoint,
    }

    public enum DatabaseLogin {
        AccessKey,
        SecretKey,
    }
}
