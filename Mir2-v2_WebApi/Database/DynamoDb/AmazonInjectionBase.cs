using Amazon.DynamoDBv2.DataModel;
using Microsoft.Extensions.DependencyInjection;
using Mir2_v2_WebApi.DynamoDb;
namespace Mir2_v2_WebApi.InjectionHandlers {
    public static class AmazonInjectionBase {
        private static readonly bool hasInjected = false;

        public static void InjectBaseServices(IServiceCollection _services) {
            if (hasInjected)
                return;
            _services.AddSingleton(DynamoHelper.GetClient());
            _services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
        }
    }
}
