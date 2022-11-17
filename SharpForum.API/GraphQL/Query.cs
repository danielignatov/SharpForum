using HotChocolate;
using HotChocolate.Data;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
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
    }
}