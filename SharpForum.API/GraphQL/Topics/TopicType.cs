using HotChocolate;
using HotChocolate.Types;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Collections.Generic;

namespace SharpForum.API.GraphQL.Topics
{
    public class TopicType : ObjectType<Topic>
    {
        protected override void Configure(IObjectTypeDescriptor<Topic> descriptor)
        {
            descriptor
                .Description("Topics");

            descriptor
                .Field(x => x.AuthorId)
                .Description("Topic author identifier");

            descriptor
                .Field(x => x.Author)
                .ResolveWith<Resolvers>(x => x.GetAuthor(default!, default!))
                .Description("Topic author");

            descriptor
                .Field(x => x.CategoryId)
                .Description("Topic category identifier");

            descriptor
                .Field(x => x.Category)
                .ResolveWith<Resolvers>(x => x.GetCategory(default!, default!))
                .Description("Topic category");

            descriptor
                .Field(x => x.CreatedOn)
                .Description("Topic creation date and time (in UTC)");

            descriptor
                .Field(x => x.Id)
                .Description("Globally unique identifier (GUID)");

            descriptor
                .Field(x => x.Locked)
                .Description("Topic is closed for new replies");

            descriptor
                .Field(x => x.Message)
                .Description("Topic message body");

            descriptor
                .Field(x => x.Removed)
                .Description("Topic is considered as removed");

            descriptor
                .Field(x => x.Replies)
                .ResolveWith<Resolvers>(x => x.GetReplies(default!, default!))
                .Description("Topic replies");

            descriptor
                .Field(x => x.Sticky)
                .Description("Topic should stick on top");

            descriptor
                .Field(x => x.Subject)
                .Description("Topic subject");

            descriptor
                .Field(x => x.UpdatedOn)
                .Description("Last updated date and time (in UTC)");
        }

        private class Resolvers
        {
            public async Task<Category> GetCategory([Parent] Topic topic, [Service] ISharpForumData data)
            {
                return await data.Categories.GetByIdAsync(topic.CategoryId);
            }

            public async Task<User> GetAuthor([Parent] Topic topic, [Service] ISharpForumData data)
            {
                return await data.Users.GetByIdAsync(topic.AuthorId);
            }

            public async Task<IEnumerable<Reply>> GetReplies([Parent] Topic topic, [Service] ISharpForumData data)
            {
                return await data.Replies.GetByTopicAsync(topic.Id);
            }
        }
    }
}