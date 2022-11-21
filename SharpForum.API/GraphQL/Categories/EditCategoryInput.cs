namespace SharpForum.API.GraphQL.Categories
{
    public record EditCategoryInput(Guid CategoryId, string Name, string Description, bool IsPlaceholder, int DisplayOrder);
}