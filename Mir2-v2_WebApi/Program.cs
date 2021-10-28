using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
namespace Mir2_v2_WebApi {
    public class Program {
        public static void Main(string[] _args) {
            CreateHostBuilder(_args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] _args) {

            IHostBuilder hostBuilder = Host.CreateDefaultBuilder(_args);
            hostBuilder.ConfigureAppConfiguration(config => config.AddJsonFile("DatabaseSettings.json"));
            hostBuilder.ConfigureWebHostDefaults(_webBuilder => {
                _webBuilder.UseStartup<Startup>();
            });
            
            return hostBuilder;
        }
    }
}
