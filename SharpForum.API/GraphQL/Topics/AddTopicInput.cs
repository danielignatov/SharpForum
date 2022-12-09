namespace SharpForum.API.GraphQL.Topics
{
    public record AddTopicInput(
        Guid AuthorId,
        Guid CategoryId,
        string Subject,
        string Message,
        bool Sticky,
        bool Locked
    );
}