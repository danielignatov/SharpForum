namespace SharpForum.API.GraphQL.Topics
{
    public record AddTopicInput(Guid AuthorId, Guid CategoryId, string Message, bool Sticky, string Subject);
}