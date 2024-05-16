using HotChocolate;
using HotChocolate.Authorization;
using HotChocolate.Data;
using Microsoft.AspNetCore.Http;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Security;
using System.Collections.Generic;

namespace SharpForum.API.GraphQL
{
    [GraphQLDescription("SharpForum available queries.")]
    public class Query
    {
        // Note: If you use more than one middleware, keep in mind that ORDER MATTERS.
        // The correct order is UsePaging > UseProjections > UseFiltering > UseSorting

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable categories.")]
        public async Task<IEnumerable<Category>> GetCategories([Service] ISharpForumData data)
        {
            return await data.Categories.GetAllCachedAsync();
        }

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable topics.")]
        public async Task<IEnumerable<Topic>> GetTopics([Service] ISharpForumData data)
        {
            return await data.Topics.GetAllCachedAsync();
        }

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable replies.")]
        public async Task<IEnumerable<Reply>> GetReplies([Service] ISharpForumData data)
        {
            return await data.Replies.GetAllCachedAsync();
        }

        [UseFiltering]
        [UseSorting]
        [GraphQLDescription("Gets the queryable users.")]
        public async Task<IEnumerable<User>> GetUsers([Service] ISharpForumData data)
        {
            return await data.Users.GetAllCachedAsync();
        }

        [GraphQLDescription("Gets the queryable roles.")]
        public async Task<IEnumerable<Role>> GetRoles([Service] ISharpForumData data)
        {
            return await data.Roles.GetAllCachedAsync();
        }

        [Authorize]
        [GraphQLDescription("Gets current user by authorization token.")]
        public async Task<User> GetCurrentUser([Service] ISharpForumData data, [Service] ITokenService tokenService, [Service] IHttpContextAccessor httpContext)
        {
            var token = 
                httpContext
                .HttpContext?
                .Request?
                .Headers["Authorization"]
                .ToString()
                .Split(" ")[1];

            var claims = 
                tokenService.DecodeToken(token);

            DateTimeOffset dateTimeOffset = 
                DateTimeOffset.FromUnixTimeSeconds(long.Parse(claims["exp"]));

            var expiration = 
                dateTimeOffset.UtcDateTime;

            if (DateTime.UtcNow > expiration)
                throw new GraphQLException("Token is expired");

            var userId =
                Guid.Parse(claims["nameid"]);

            var user = await data.Users.GetByIdAsync(userId);

            if (user == null)
                throw new GraphQLException("User not found");

            return user;
        }
    }
}