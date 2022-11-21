namespace SharpForum.API.GraphQL.Users
{
    public record EditUserInput(Guid UserId, string About, string Avatar, string DisplayName, string Email, string Location, string Signature, string Website);
}