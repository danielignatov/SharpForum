using HotChocolate.Types;
using HotChocolate;
using HotChocolate.Subscriptions;
using SharpForum.API.Data.Repository.Interfaces;
using System.Threading;

namespace SharpForum.API.GraphQL.Users
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("User mutations")]
    public class UserMutation
    {
        public async Task<EditUserPayload> EditUserAsync(
            EditUserInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var user = await data.Users.GetByIdAsync(input.UserId);

            if (user == null)
                throw new GraphQLException(new Error("User not found."));

            user.About = input.About;
            user.Avatar = input.Avatar;
            user.DisplayName = input.DisplayName;
            user.Email = input.Email;
            user.Location = input.Location;
            user.Signature = input.Signature;
            user.Website = input.Website;
            user.UpdatedOn = DateTime.UtcNow;

            bool success = data.Users.Update(user);

            if (!success)
                throw new GraphQLException(new Error("Problem updating user."));

            await eventSender.SendAsync(nameof(Subscription.OnUserUpdated), user, cancellationToken);

            return new EditUserPayload(user);
        }

        public async Task RemoveUserAsync(
            RemoveUserInput input,
            [Service] ISharpForumData data,
            [Service] ITopicEventSender eventSender,
            CancellationToken cancellationToken)
        {
            var user = await data.Users.GetByIdAsync(input.UserId);

            if (user == null)
                throw new GraphQLException(new Error("User not found."));

            user.UpdatedOn = DateTime.UtcNow;
            user.Removed = true;

            bool success = data.Users.Update(user);

            if (!success)
                throw new GraphQLException(new Error("Problem removing user."));

            await eventSender.SendAsync(nameof(Subscription.OnUserRemoved), user.Id, cancellationToken);
        }
    }
}