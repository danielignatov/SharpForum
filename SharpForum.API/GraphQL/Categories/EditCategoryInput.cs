namespace SharpForum.API.GraphQL.Categories
{
    public record EditCategoryInput(Guid CategoryId, string Name, string Description, int DisplayOrder, bool IsPlaceholder);
}