using System.Linq;
using SharpForum.API.Extensions;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;
using NSwag.Generation.Processors.Security;
using SharpForum.Persistence;
using SharpForum.Repository.Interfaces;
using SharpForum.Repository;

namespace SharpForum.API
{
    public class Startup
    {
        private readonly IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Register the Swagger services
            services.AddSwaggerDocument(settings =>
            {
                settings.Title = "SharpForum API";
                settings.SchemaType = NJsonSchema.SchemaType.OpenApi3;
                settings.OperationProcessors.Add(new OperationSecurityScopeProcessor("JWT Token"));
                settings.AddSecurity("JWT Token", Enumerable.Empty<string>(),
                    new OpenApiSecurityScheme()
                    {
                        Type = OpenApiSecuritySchemeType.ApiKey,
                        Name = "Authorization",
                        In = OpenApiSecurityApiKeyLocation.Header,
                        Description = "Copy this into the value field: Bearer {token}"
                    }
                );
            });

            services.AddDbContext<DataContext>(option =>
            {
                //option.UseSqlite(_config.GetConnectionString("SQLite"));
                option.UseSqlServer(_config.GetConnectionString("MSSQL"));
            });

            services.AddMediatR(typeof(Application.Categories.CategoryList).Assembly);

            // Adding Unit of work to the DI container
            services.AddScoped<ISharpForumData, SharpForumData>();

            services.AddIdentityServices(_config);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // Register the Swagger generator and the Swagger UI middlewares
                app.UseOpenApi();
                app.UseSwaggerUi3();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}