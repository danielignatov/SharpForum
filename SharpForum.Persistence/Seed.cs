using SharpForum.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SharpForum.Persistence
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            if (context.Categories.Any()) return;

            var categories = new List<Category>
            {
                new Category
                {
                    Name = "Home",
                    Description = "Default home category",
                    Order = 0,
                    IsPlaceholder = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                },
                new Category
                {
                    Name = "News",
                    Description = "News about the forum",
                    Order = 1,
                    IsPlaceholder = false,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                },
                new Category
                {
                    Name = "Introduction",
                    Description = "Tell us about yourself",
                    Order = 2,
                    IsPlaceholder = false,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                },
                new Category
                {
                    Name = "Entertainment",
                    Description = "Default entertainment category",
                    Order = 3,
                    IsPlaceholder = true,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                },
                new Category
                {
                    Name = "Movies",
                    Description = "Discuss movies here",
                    Order = 4,
                    IsPlaceholder = false,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                },
                new Category
                {
                    Name = "Music",
                    Description = "Discuss music here",
                    Order = 5,
                    IsPlaceholder = false,
                    CreatedOn = DateTime.UtcNow,
                    UpdatedOn = DateTime.UtcNow
                }
            };

            await context.Categories.AddRangeAsync(categories);
            await context.SaveChangesAsync();
        }
    }
}
