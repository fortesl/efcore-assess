using System;

namespace Fortes.Assess.WebApi
{
    using Fortes.Assess.Data.EF;
    using Fortes.Assess.Data.Repositories;
    using Fortes.Assess.Data.Repositories.DisconnectedData;
    using Fortes.Assess.Domain;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Diagnostics;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Newtonsoft.Json;
    using Swashbuckle.AspNetCore.Swagger;

    public class Startup
    {
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        private readonly ILogger _logger;

        public Startup(IConfiguration configuration, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            _configuration = configuration;
            _env = env;
            _logger = loggerFactory.CreateLogger<Startup>();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            _logger.LogInformation(_env.IsDevelopment()
                ? "Development Environment"
                : $"Environment: {_env.EnvironmentName}");

            /* For accessing current httpContext */
            services.AddHttpContextAccessor();

            services.AddDbContext<AssessDbContext>(options => options
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .EnableSensitiveDataLogging()
                //                .UseLazyLoadingProxies()
                .ConfigureWarnings(warnigs => warnigs.Throw(RelationalEventId
                    .QueryClientEvaluationWarning))
                .UseSqlServer(_configuration.GetValue<string>("ConnectionStrings:AzureAssessDb"),
                    sqlServerOptionsAction: sqlOptions =>
                    {
                        sqlOptions.EnableRetryOnFailure(
                            maxRetryCount: 2,
                            maxRetryDelay: TimeSpan.FromSeconds(20),
                            errorNumbersToAdd: null);
                    }));

            AddServices(services);

            services.AddCors();

            services.AddMvc()
                .AddJsonOptions(options => options
                    .SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore)
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Fortes.Assess.WebApi", Version = "v1", Description = "Assess backend api"});
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (_env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // Use the HTTP Strict Transport Security Protocol(HSTS) middleware
                app.UseHsts();
            }

            app.UseCors();

            // Use HTTPS Redirection Middleware to redirect HTTP requests to HTTPS.
            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Fortes.Assess.WebApi V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseMvc();
        }

        private void AddServices(IServiceCollection services)
        {

            services.AddScoped<IRepository<User>, Repository<User>>();
            services.AddScoped<IRepository<Question>, Repository<Question>>();
            services.AddScoped<IRepository<Assessment>, Repository<Assessment>>();
            services.AddScoped<IRepository<UserPage>, Repository<UserPage>>();
            services.AddScoped<IRepository<AdminPage>, Repository<AdminPage>>();
        }
    }
}
