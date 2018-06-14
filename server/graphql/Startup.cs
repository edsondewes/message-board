using GraphQL;
using GraphQL.Http;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Ui.Playground;
using GraphQL.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MessageBoard.GraphQL
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<IDependencyResolver>(s => new FuncDependencyResolver(s.GetRequiredService));
            services.AddSingleton<IDocumentExecuter, DocumentExecuter>();
            services.AddSingleton<IDocumentWriter, DocumentWriter>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddGraphQLHttp();
            services.Configure<ExecutionOptions>(options =>
            {
                options.EnableMetrics = true;
                options.ExposeExceptions = true;
            });

            services.AddGRPC(_configuration);
            services.AddMessageBoardSchema();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // add http for Schema at default url /graphql
            app.UseGraphQLHttp<ISchema>(new GraphQLHttpOptions());

            // use graphql-playground at url /
            app.UseGraphQLPlayground(new GraphQLPlaygroundOptions
            {
                Path = "/"
            });
        }
    }
}
