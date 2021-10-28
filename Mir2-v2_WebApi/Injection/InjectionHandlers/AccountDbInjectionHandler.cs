using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mir2_v2_WebApi.Broker;
using Mir2_v2_WebApi.Database;
using Mir2_v2_WebApi.Database.AzurePostgres;
using Mir2_v2_WebApi.Database.DynamoDb;
using Mir2_v2_WebApi.InjectionHandlers;
using Newtonsoft.Json.Linq;
namespace Mir2_v2_WebApi.Helpers.InjectionHandlers {
    public class AccountDbInjectionHandler {

        public void SetDatabaseInjection(IServiceCollection _services, IConfiguration _configuration, DbProvider _dbProvider) {
            switch (_dbProvider) {
                case DbProvider.AwsDynamo:
                    InjectAwsDynamo(_services);
                    break;
                case DbProvider.AwsMySql:
                    InjectAwsMySql(_services);
                    break;
                case DbProvider.AzurePostgres:
                    InjectAzurePostgres(_services, _configuration);
                    break;
                case DbProvider.LocalPostgres:
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(_dbProvider), _dbProvider, null);
            }
        }
        private void InjectAzurePostgres(IServiceCollection _services, IConfiguration _configuration) {
            // // _services.AddSingleton<IDataAccess, AzurePostgresAccountRepository>();
            JToken dbConnSettings = _configuration.GetValue<JToken>("database.postgres-dev");
            
            var connectionString = $"server={dbConnSettings["server"]};database={dbConnSettings["name"]};Port={dbConnSettings["port"]};user id={dbConnSettings["username"]}; password={dbConnSettings["password"]};pooling=true;";
            _services.AddDbContext<AccountBroker>(_context => _context.UseNpgsql(connectionString));
            // _services.AddSingleton<IDataAccess, DynamoDbAccountRepository>();
        }
        
        private void InjectAwsMySql(IServiceCollection _services) {
            throw new NotImplementedException();
        }

        private void InjectAwsDynamo(IServiceCollection _services) {
            AmazonInjectionBase.InjectBaseServices(_services);
            _services.AddSingleton<IDataAccess, DynamoDbAccountRepository>();
        }
    }
}
