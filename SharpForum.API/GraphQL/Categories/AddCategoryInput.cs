namespace SharpForum.API.GraphQL.Categories
{
    public record AddCategoryInput(string Name, string Description, bool IsPlaceholder, int DisplayOrder);
}