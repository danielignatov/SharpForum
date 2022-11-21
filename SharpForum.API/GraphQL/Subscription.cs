using HotChocolate.Types;
using HotChocolate;
using SharpForum.API.Models.Domain;

namespace SharpForum.API.GraphQL
{
    public class Subscription
    {
        [Subscribe]
        [Topic]
        public Topic OnTopicAdded([EventMessage] Topic topic)
        {
            return topic;
        }

        [Subscribe]
        [Topic]
        public Topic OnTopicUpdated([EventMessage] Topic topic)
        {
            return topic;
        }

        [Subscribe]
        [Topic]
        public Guid OnTopicRemoved([EventMessage] Guid topicId)
        {
            return topicId;
        }

        [Subscribe]
        [Topic]
        public Reply OnReplyAdded([EventMessage] Reply reply)
        {
            return reply;
        }

        [Subscribe]
        [Topic]
        public Reply OnReplyUpdated([EventMessage] Reply reply)
        {
            return reply;
        }

        [Subscribe]
        [Topic]
        public Guid OnReplyRemoved([EventMessage] Guid replyId)
        {
            return replyId;
        }

        [Subscribe]
        [Topic]
        public User OnUserUpdated([EventMessage] User user)
        {
            return user;
        }

        [Subscribe]
        [Topic]
        public Guid OnUserRemoved([EventMessage] Guid userId)
        {
            return userId;
        }
    }
}