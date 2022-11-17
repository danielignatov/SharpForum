using HotChocolate;
using HotChocolate.Types;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SharpForum.API.GraphQL.Categories
{
    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor
                .Description("Categories");

            descriptor
                .Field(x => x.CreatedOn)
                .Description("Category creation date and time (in UTC)");

            descriptor
                .Field(x => x.Description)
                .Description("Category description");

            descriptor
                .Field(x => x.Id)
                .Description("Globally unique identifier (GUID)");

            descriptor
                .Field(x => x.IsPlaceholder)
                .Description("Category act like placeholder, does not allow topic creation");

            descriptor
                .Field(x => x.Name)
                .Description("Category name");

            descriptor
                .Field(x => x.DisplayOrder)
                .Description("Category display order");

            descriptor
                .Field(x => x.Removed)
                .Description("Category is considered as removed");

            descriptor
                .Field(x => x.Topics)
                .ResolveWith<Resolvers>(x => x.GetTopics(default!, default!))
                .Description("List of topics in category")
                .UseFiltering()
                .UseSorting();

            descriptor
                .Field(x => x.UpdatedOn)
                .Description("Last updated date and time (in UTC)");
        }

        private class Resolvers
        {
            public async Task<IEnumerable<Topic>> GetTopics([Parent] Category category, [Service] ISharpForumData data)
            {
                var topics = await data.Topics.GetAllCachedAsync();

                return topics.Where(x => x.CategoryId == category.Id);
            }
        }
    }
}