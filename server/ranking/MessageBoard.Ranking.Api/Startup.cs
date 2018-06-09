using App.Metrics.Health;
using MediatR;
using MessageBoard.Ranking.GRPC;
using MessageBoard.Ranking.Nats;
using MessageBoard.Ranking.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json.Serialization;

namespace MessageBoard.Ranking.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(o => o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver());

            services.AddRedis(Configuration.GetValue<string>("Redis"));
            services.AddNats(Configuration.GetValue<string>("Nats"));
            services.AddGRPCServer();
            services.AddMediatR();

            services.AddHealth(
                AppMetricsHealth.CreateDefaultBuilder()
                    .HealthChecks.RegisterFromAssembly(services)
                    .BuildAndAddTo(services));
            services.AddHealthEndpoints();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseCors(builder => builder
                    .AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            }

            app.UseHealthEndpoint();
            app.UseMvc();
        }
    }
}
