namespace SharpForum.API.GraphQL.Users
{
    public record LoginUserPayload(string token, DateTime expiration);
}