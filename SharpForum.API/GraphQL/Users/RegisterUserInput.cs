namespace SharpForum.API.GraphQL.Users
{
    public record RegisterUserInput(string DisplayName, string Password, string Email);
}