using HotChocolate.Types;
using HotChocolate;
using SharpForum.API.Data.Repository.Interfaces;
using SharpForum.API.Models.Domain;
using HotChocolate.Authorization;

namespace SharpForum.API.GraphQL.Categories
{
    [ExtendObjectType(typeof(Mutation))]
    [GraphQLDescription("Category mutations")]
    public class CategoryMutation
    {
        [Authorize]
        public async Task<AddCategoryPayload> AddCategoryAsync(
            AddCategoryInput input,
            [Service] ISharpForumData data)
        {
            var category = new Category
            {
                CreatedOn = DateTime.UtcNow,
                Description = input.Description,
                DisplayOrder = input.DisplayOrder,
                Id = Guid.NewGuid(),
                IsPlaceholder = input.IsPlaceholder,
                Name = input.Name,
                Removed = false,
                UpdatedOn = DateTime.UtcNow,
            };
        
            bool success = await data.Categories.AddAsync(category);

            if (!success)
                throw new GraphQLException(new Error("Problem adding category."));

            return new AddCategoryPayload(category);
        }

        [Authorize]
        public async Task<EditCategoryPayload> EditCategoryAsync(
            EditCategoryInput input,
            [Service] ISharpForumData data)
        {
            var category = await data.Categories.GetByIdAsync(input.CategoryId);

            if (category == null)
                throw new GraphQLException(new Error("Category not found."));

            category.Description = input.Description;
            category.DisplayOrder = input.DisplayOrder;
            category.IsPlaceholder = input.IsPlaceholder;
            category.Name = input.Name;
            category.UpdatedOn = DateTime.UtcNow;
            
            bool success = data.Categories.Update(category);

            if (!success)
                throw new GraphQLException(new Error("Problem updating category."));

            return new EditCategoryPayload(category);
        }

        [Authorize]
        public async Task<RemoveCategoryPayload> RemoveCategoryAsync(
            RemoveCategoryInput input,
            [Service] ISharpForumData data)
        {
            var category = await data.Categories.GetByIdAsync(input.CategoryId);

            if (category == null)
                throw new GraphQLException(new Error("Category not found."));

            category.UpdatedOn = DateTime.UtcNow;
            category.Removed = true;

            bool success = data.Categories.Update(category);

            if (!success)
                throw new GraphQLException(new Error("Problem removing category."));

            return new RemoveCategoryPayload(success);
        }
    }
}