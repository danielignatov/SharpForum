namespace SharpForum.Data
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SharpForum.Models.EntityModels;
    using System;
    using System.Linq;

    public static class SeedValues
    {
        public static void Roles(SharpForumContext context)
        {
            if (!context.Roles.Any())
            {
                var adminRole = new IdentityRole("Admin");
                var moderatorRole = new IdentityRole("Moderator");
                var userRole = new IdentityRole("User");

                context.Roles.Add(adminRole);
                context.Roles.Add(moderatorRole);
                context.Roles.Add(userRole);

                context.SaveChanges();
            }
        }

        public static void Categories(SharpForumContext context)
        {
            if (!context.Categories.Any())
            {
                Category homeCategory = new Category()
                {
                    Name = "Home",
                    Description = "Default home category",
                    Priority = 1,
                    IsCategoryPlaceholder = true
                };

                Category newsCategory = new Category()
                {
                    Name = "News",
                    Description = "News about the forum",
                    Priority = 2,
                    IsCategoryPlaceholder = false
                };

                Category introductionCategory = new Category()
                {
                    Name = "Introduction",
                    Description = "Tell us about yourself",
                    Priority = 3,
                    IsCategoryPlaceholder = false
                };

                Category entertainmentCategory = new Category()
                {
                    Name = "Entertainment",
                    Description = "Default entertainment category",
                    Priority = 4,
                    IsCategoryPlaceholder = true
                };

                Category moviesCategory = new Category()
                {
                    Name = "Movies",
                    Description = "Discuss movies here",
                    Priority = 5,
                    IsCategoryPlaceholder = false
                };

                Category musicCategory = new Category()
                {
                    Name = "Music",
                    Description = "Discuss music here",
                    Priority = 6,
                    IsCategoryPlaceholder = false
                };

                context.Categories.Add(homeCategory);
                context.Categories.Add(newsCategory);
                context.Categories.Add(introductionCategory);
                context.Categories.Add(entertainmentCategory);
                context.Categories.Add(moviesCategory);
                context.Categories.Add(musicCategory);

                context.SaveChanges();
            }
        }

        public static void Users(SharpForumContext context)
        {
            if (!context.Users.Any())
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                User admin = new User()
                {
                    Email = "admin@example.com",
                    UserName = "Admin",
                    AboutMe = "I am example admin.",
                    WebsiteUrl = "https://example.com/",
                    AvatarUrl = "../content/avatars/avatar1.png",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "Admin signature",
                    RoleTitle = "Admin",
                    LivingLocation = "Sofia"
                };

                manager.Create(admin, "Admin1");
                manager.AddToRole(admin.Id, "Admin");

                User moderator = new User()
                {
                    Email = "moderator@example.com",
                    UserName = "Moderator",
                    AboutMe = "I am example moderator.",
                    WebsiteUrl = "https://example.com/",
                    AvatarUrl = "../content/avatars/avatar2.png",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "Moderator signature",
                    RoleTitle = "Moderator",
                    LivingLocation = "Bulgaria"
                };

                manager.Create(moderator, "Moderator1");
                manager.AddToRole(moderator.Id, "Moderator");

                User user = new User()
                {
                    Email = "user@example.com",
                    UserName = "User",
                    AboutMe = "I am example user.",
                    WebsiteUrl = "https://example.com/",
                    AvatarUrl = "../content/avatars/avatar3.png",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "User signature",
                    RoleTitle = "User"
                };

                manager.Create(user, "User12");
                manager.AddToRole(user.Id, "User");
            }

            context.SaveChanges();
        }
    }
}