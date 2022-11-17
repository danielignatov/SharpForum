using HotChocolate;
using HotChocolate.Data;
using SharpForum.API.Data.Repository.Interfaces;
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
        public async Task<IEnumerable<Models.Domain.Category>> GetCategories([Service] ISharpForumData data)
        {
            return await data.Categories.GetAllCachedAsync();
        }
    }
}
