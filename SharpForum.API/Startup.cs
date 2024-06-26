﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Data.Repository;
using SharpForum.API.Data;
using SharpForum.API.Services.Caching;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Authentication;
using SharpForum.API.GraphQL.Categories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using SharpForum.API.GraphQL;
using SharpForum.API.GraphQL.Replies;
using SharpForum.API.GraphQL.Topics;
using SharpForum.API.GraphQL.Roles;
using SharpForum.API.GraphQL.Users;
using SharpForum.API.Services.Security;
using Microsoft.AspNetCore.Http;

namespace SharpForum.API
{
    public class Startup
    {
        private readonly string AllowedOrigin = "allowedOrigin";

        public Startup(IConfiguration config)
        {
            Configuration = config;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            //services.TryAddSingleton<ISystemClock, SystemClock>();

            var connString = Configuration.GetConnectionString("MySQL");

            services.AddPooledDbContextFactory<DataContext>(opt => {
                opt.UseMySql(connString, ServerVersion.AutoDetect(connString));
                opt.EnableSensitiveDataLogging(true);
            });

            services.AddAuthorization();

            services.AddMemoryCache();

            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(Configuration["TokenKey"]));

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(opt =>
                {
                    opt.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = key,
                        ValidateAudience = false,
                        ValidateIssuer = false,
                        ValidateLifetime = true,
                        ClockSkew = TimeSpan.Zero
                    };
                });

            services.AddSingleton<ICacheManager, CacheManager>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddScoped<ISharpForumData, SharpForumData>();

            services.AddScoped<IPasswordService, PasswordService>();

            services.AddScoped<ITokenService, TokenService>();

            services.AddCors(option => {
                option.AddPolicy(AllowedOrigin,
                    builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()
                    );
            });

            // GraphQL
            services
                .AddGraphQLServer()
                .RegisterService<ISharpForumData>()
                .AddQueryType<Query>()
                .AddType<CategoryType>()
                .AddType<ReplyType>()
                .AddType<RoleType>()
                .AddType<TopicType>()
                .AddType<UserType>()
                .AddAuthorization()
                .AddMutationType<Mutation>()
                .AddTypeExtension<AuthMutation>()
                .AddTypeExtension<CategoryMutation>()
                .AddTypeExtension<ReplyMutation>()
                .AddTypeExtension<TopicMutation>()
                .AddSubscriptionType<Subscription>()
                .AddProjections()
                .AddFiltering()
                .AddSorting()
                .AddInMemorySubscriptions();

            services.AddErrorFilter<GraphQLErrorFilter>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllowedOrigin);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGraphQL("/graphql");
            });
        }
    }
}