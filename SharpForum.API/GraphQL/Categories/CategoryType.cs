using HotChocolate.Types;
using SharpForum.API.Models.Domain;

namespace SharpForum.API.GraphQL.Categories
{
    public class CategoryType : ObjectType<Category>
    {
        protected override void Configure(IObjectTypeDescriptor<Category> descriptor)
        {
            descriptor
                .Description("Categories");

            descriptor
                .Field(x => x.Description)
                .Description("Category description");

            descriptor
                .Field(x => x.Order)
                .Description("Category display order");
        }
    }
}