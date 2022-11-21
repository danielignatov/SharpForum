namespace SharpForum.API.GraphQL.Users
{
    public record RegisterUserInput(string Email, string Password, string About, string Avatar, string DisplayName, string Location, string Signature, string Website);
}