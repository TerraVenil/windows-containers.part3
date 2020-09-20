using System.Reflection;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace ImageYRotator
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var controllersAssembly = Assembly.Load(typeof(PingsController).Assembly.FullName);

            services
                .AddMvcCore()
                .AddFormatterMappings()
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver
                    {
                        NamingStrategy = new CamelCaseNamingStrategy
                        {
                            ProcessDictionaryKeys = true
                        }
                    };
                })
                .AddJsonFormatters()
                .AddApplicationPart(controllersAssembly)
                .AddControllersAsServices()
                .AddApiExplorer();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvcWithDefaultRoute();
        }
    }
}