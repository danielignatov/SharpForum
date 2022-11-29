using SharpForum.API.Models.Domain;

namespace SharpForum.API.GraphQL.Users
{
    public record LoginUserPayload(string Token, DateTime Expiration, User User);
}