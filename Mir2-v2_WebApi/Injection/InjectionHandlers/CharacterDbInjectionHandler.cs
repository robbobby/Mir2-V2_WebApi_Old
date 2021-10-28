using System;
using Microsoft.Extensions.DependencyInjection;
using Mir2_v2_WebApi.Database;
using Mir2_v2_WebApi.Database.DynamoDb;
using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.InjectionHandlers {
    public class CharacterDbInjectionHandler {
        public static void SetDatabaseInjection(IServiceCollection _services, DbProvider _dbProvider) {
            switch (_dbProvider) {
                case DbProvider.AwsDynamo:
                    UseAwsDynamo(_services);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_dbProvider), _dbProvider, null);
            }
        }

        private static void UseAwsDynamo(IServiceCollection _services) {
            AmazonInjectionBase.InjectBaseServices(_services);
            _services.AddSingleton<IDataAccess, DynamoDbAccountRepository>();
        }
    }
}
