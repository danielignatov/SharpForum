using HotChocolate;
using HotChocolate.Types;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Collections.Generic;

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
                .ResolveWith<Resolvers>(x => Resolvers.GetTopics(default!, default!))
                .Description("List of topics in category")
                .UseFiltering()
                .UseSorting();

            descriptor
                .Field(x => x.UpdatedOn)
                .Description("Last updated date and time (in UTC)");

            descriptor
                .Field("topicCount")
                .ResolveWith<Resolvers>(x => Resolvers.GetTopicCount(default!, default!))
                .Description("Total count of topics in category");

            descriptor
                .Field("replyCount")
                .ResolveWith<Resolvers>(x => Resolvers.GetReplyCount(default!, default!))
                .Description("Total count of topic replies in category");
        }

        private class Resolvers
        {
            public static async Task<IEnumerable<Topic>> GetTopics([Parent] Category category, [Service] ISharpForumData data)
            {
                return await data.Topics.GetByCategoryAsync(category.Id);
            }

            public static async Task<int> GetTopicCount([Parent] Category category, [Service] ISharpForumData data)
            {
                return await data.Categories.GetTopicCountAsync(category.Id);
            }

            public static async Task<int> GetReplyCount([Parent] Category category, [Service] ISharpForumData data)
            {
                return await data.Categories.GetReplyCountAsync(category.Id);
            }
        }
    }
}