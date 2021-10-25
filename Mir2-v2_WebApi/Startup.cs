using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.DataModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Mir2_v2_WebApi.DynamoDb;

namespace Mir2_v2_WebApi {
    public class Startup {
        public Startup(IConfiguration _configuration) {
            Configuration = _configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection _services) {

            _services.AddControllers();
            _services.AddSwaggerGen(_c => {
                _c.SwaggerDoc("v1", new OpenApiInfo {
                    Title = "Mir2_v2_WebApi",
                    Version = "v1"
                });
            });
            

            _services.AddSingleton<IAmazonDynamoDB>(DynamoHelper.GetClient());
            _services.AddSingleton<IDynamoDBContext, DynamoDBContext>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder _app, IWebHostEnvironment _env) {
            if (_env.IsDevelopment()) {
                _app.UseDeveloperExceptionPage();
                _app.UseSwagger();
                _app.UseSwaggerUI(_config => _config.SwaggerEndpoint("/swagger/v1/swagger.json", "Mir2_v2_WebApi v1"));
            }

            _app.UseHttpsRedirection();

            _app.UseRouting();

            _app.UseAuthorization();

            _app.UseEndpoints(_endpoints => {
                _endpoints.MapControllers();
            });
        }
    }
}
