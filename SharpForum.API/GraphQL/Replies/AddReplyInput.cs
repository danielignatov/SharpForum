namespace SharpForum.API.GraphQL.Replies
{
    public record AddReplyInput(Guid AuthorId, string Message, Guid TopicId);
}