using SharpForum.API.Models.Domain;
using System.Collections.Generic;
using System.Linq;

namespace SharpForum.API.Data
{
    public class Seed
    {
        public static async Task SeedData(DataContext context)
        {
            var adminId = Guid.Parse("7b005610-8ebd-4b9f-bbe7-f58b47d9b3ff");
            var adminRoleId = Guid.Parse("ca37cd73-ded7-47b2-9399-e1ff55668d0c");

            if (!context.Roles.Any())
            {
                var roles = new List<Role>
                {
                    new Role
                    {
                        Id = Guid.Parse("63b7e5d3-96ca-4c99-a75c-e0c358ad6bf1"),
                        Name = "User"
                    },
                    new Role
                    {
                        Id = Guid.Parse("f36f8c6b-d163-4fe8-b986-668bc18cafc5"),
                        Name = "Moderator"
                    },
                    new Role
                    {
                        Id = adminRoleId,
                        Name = "Admin"
                    }
                };

                await context.Roles.AddRangeAsync(roles);
                await context.SaveChangesAsync();
            }

            if (!context.Users.Any())
            {
                var users = new List<User> 
                { 
                    new User
                    {
                        About = "Admin of SharpForum",
                        Avatar = "",
                        CreatedOn = DateTime.UtcNow,
                        DisplayName = "Admin",
                        Email = "admin@sharpforum.com",
                        Id = adminId,
                        Location = "Sofia, Bulgaria",
                        PasswordHash = "FqyCpJLIo88=",
                        Removed = false,
                        RoleId = adminRoleId,
                        Signature = "Signature",
                        UpdatedOn = DateTime.UtcNow,
                        Website = "www.sharpforum.com"
                    }
                };

                await context.Users.AddRangeAsync(users);
                await context.SaveChangesAsync();
            }

            if (!context.Categories.Any())
            {
                var categories = new List<Category>
                {
                    new Category
                    {
                        Name = "Home",
                        Description = "Default home category",
                        DisplayOrder = 0,
                        IsPlaceholder = true,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "News",
                        Description = "News about the forum",
                        DisplayOrder = 1,
                        IsPlaceholder = false,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Introduction",
                        Description = "Tell us about yourself",
                        DisplayOrder = 2,
                        IsPlaceholder = false,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Entertainment",
                        Description = "Default entertainment category",
                        DisplayOrder = 3,
                        IsPlaceholder = true,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Movies",
                        Description = "Discuss movies here",
                        DisplayOrder = 4,
                        IsPlaceholder = false,
                        CreatedOn = DateTime.UtcNow,
                        UpdatedOn = DateTime.UtcNow
                    },
                    new Category
                    {
                        Name = "Music",
                        Description = "Discuss music here",
                        DisplayOrder = 5,
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
}