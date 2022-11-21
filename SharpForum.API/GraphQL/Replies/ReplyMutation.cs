using HotChocolate.Types;
using HotChocolate;
using HotChocolate.Subscriptions;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Threading;
using SharpForum.API.GraphQL.Categories;

namespace SharpForum.API.GraphQL.Replies
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Reply mutations")]
    public class ReplyMutation
    {
        public async Task<AddReplyPayload> AddReplyAsync(
            AddReplyInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var reply = new Reply
            {
                CreatedOn = DateTime.UtcNow,
                AuthorId = input.AuthorId,
                Message = input.Message,
                Id = Guid.NewGuid(),
                TopicId = input.TopicId,
                Removed = false,
                UpdatedOn = DateTime.UtcNow,
            };

            bool success = await data.Replies.AddAsync(reply);

            if (!success)
                throw new GraphQLException(new Error("Problem adding reply."));

            await eventSender.SendAsync(nameof(Subscription.OnReplyAdded), reply, cancellationToken);

            return new AddReplyPayload(reply);
        }

        public async Task<EditReplyPayload> EditReplyAsync(
            EditReplyInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var reply = await data.Replies.GetByIdAsync(input.ReplyId);

            if (reply == null)
                throw new GraphQLException(new Error("Reply not found."));

            reply.Message = input.Message;
            reply.UpdatedOn = DateTime.UtcNow;

            bool success = data.Replies.Update(reply);

            if (!success)
                throw new GraphQLException(new Error("Problem updating reply."));

            await eventSender.SendAsync(nameof(Subscription.OnReplyUpdated), reply, cancellationToken);

            return new EditReplyPayload(reply);
        }

        public async Task RemoveReplyAsync(
            RemoveReplyInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var reply = await data.Replies.GetByIdAsync(input.ReplyId);

            if (reply == null)
                throw new GraphQLException(new Error("Reply not found."));

            reply.UpdatedOn = DateTime.UtcNow;
            reply.Removed = true;

            bool success = data.Replies.Update(reply);

            if (!success)
                throw new GraphQLException(new Error("Problem removing reply."));

            await eventSender.SendAsync(nameof(Subscription.OnReplyRemoved), reply.Id, cancellationToken);
        }
    }
}