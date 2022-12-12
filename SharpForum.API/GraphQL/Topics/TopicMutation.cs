using HotChocolate.Types;
using HotChocolate;
using HotChocolate.Subscriptions;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using System.Threading;
using HotChocolate.AspNetCore.Authorization;

namespace SharpForum.API.GraphQL.Topics
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Topic mutations")]
    public class TopicMutation
    {
        [Authorize]
        public async Task<AddTopicPayload> AddTopicAsync(
            AddTopicInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var topic = new Topic
            {
                CreatedOn = DateTime.UtcNow,
                AuthorId = input.AuthorId,
                Message = input.Message,
                Id = Guid.NewGuid(),
                CategoryId = input.CategoryId,
                Removed = false,
                UpdatedOn = DateTime.UtcNow,
                Locked = input.Locked,
                Sticky = input.Sticky,
                Subject = input.Subject
            };

            bool success = await data.Topics.AddAsync(topic);

            if (!success)
                throw new GraphQLException(new Error("Problem adding topic."));

            await eventSender.SendAsync(nameof(Subscription.OnTopicAdded), topic, cancellationToken);

            return new AddTopicPayload(topic);
        }

        [Authorize]
        public async Task<EditTopicPayload> EditTopicAsync(
            EditTopicInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var topic = await data.Topics.GetByIdAsync(input.TopicId);

            if (topic == null)
                throw new GraphQLException(new Error("Reply not found."));

            topic.CategoryId = input.CategoryId;
            topic.Locked = input.Locked;
            topic.Sticky = input.Sticky;
            topic.Subject = input.Subject;
            topic.Message = input.Message;
            topic.UpdatedOn = DateTime.UtcNow;

            bool success = data.Topics.Update(topic);

            if (!success)
                throw new GraphQLException(new Error("Problem updating topic."));

            await eventSender.SendAsync(nameof(Subscription.OnTopicUpdated), topic, cancellationToken);

            return new EditTopicPayload(topic);
        }

        [Authorize]
        public async Task RemoveTopicAsync(
            RemoveTopicInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var topic = await data.Topics.GetByIdAsync(input.TopicId);

            if (topic == null)
                throw new GraphQLException(new Error("Topic not found."));

            topic.UpdatedOn = DateTime.UtcNow;
            topic.Removed = true;

            bool success = data.Topics.Update(topic);

            if (!success)
                throw new GraphQLException(new Error("Problem removing topic."));

            await eventSender.SendAsync(nameof(Subscription.OnTopicRemoved), topic.Id, cancellationToken);
        }
    }
}