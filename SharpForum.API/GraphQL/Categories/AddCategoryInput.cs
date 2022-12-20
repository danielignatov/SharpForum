namespace SharpForum.API.GraphQL.Categories
{
    public record AddCategoryInput(string Name, string Description, int DisplayOrder, bool IsPlaceholder);
}