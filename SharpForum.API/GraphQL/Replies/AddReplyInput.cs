namespace SharpForum.API.GraphQL.Replies
{
    public record AddReplyInput(
        Guid AuthorId, 
        Guid TopicId,
        string Message
    );
}