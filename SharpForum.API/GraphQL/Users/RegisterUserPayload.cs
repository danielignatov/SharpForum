using SharpForum.API.Models.Domain;

namespace SharpForum.API.GraphQL.Users
{
    public record RegisterUserPayload(string Token, DateTime Expiration, User User);
}