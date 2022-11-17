using HotChocolate.Types;
using HotChocolate;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;

namespace SharpForum.API.GraphQL.Replies
{
    public class ReplyType : ObjectType<Reply>
    {
        protected override void Configure(IObjectTypeDescriptor<Reply> descriptor)
        {
            descriptor
                .Description("Replies");

            descriptor
                .Field(x => x.AuthorId)
                .Description("Reply author identifier");

            descriptor
                .Field(x => x.Author)
                .ResolveWith<Resolvers>(x => x.GetAuthor(default!, default!))
                .Description("Reply author");

            descriptor
                .Field(x => x.CreatedOn)
                .Description("Reply creation date and time (in UTC)");

            descriptor
                .Field(x => x.Id)
                .Description("Globally unique identifier (GUID)");

            descriptor
                .Field(x => x.Message)
                .Description("Reply message body");

            descriptor
                .Field(x => x.Removed)
                .Description("Reply is considered as removed");

            descriptor
                .Field(x => x.TopicId)
                .Description("Reply topic identifier");

            descriptor
                .Field(x => x.Topic)
                .ResolveWith<Resolvers>(x => x.GetTopic(default!, default!))
                .Description("Reply topic"); ;

            descriptor
                .Field(x => x.UpdatedOn)
                .Description("Last updated date and time (in UTC)");
        }

        private class Resolvers
        {
            public async Task<Topic> GetTopic([Parent] Reply reply, [Service] ISharpForumData data)
            {
                return await data.Topics.GetByIdAsync(reply.TopicId);
            }

            public async Task<User> GetAuthor([Parent] Reply reply, [Service] ISharpForumData data)
            {
                return await data.Users.GetByIdAsync(reply.AuthorId);
            }
        }
    }
}