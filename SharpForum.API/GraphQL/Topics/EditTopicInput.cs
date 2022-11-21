namespace SharpForum.API.GraphQL.Topics
{
    public record EditTopicInput(Guid TopicId, Guid CategoryId, string Message, bool Sticky, bool Locked, string Subject);
}