namespace SharpForum.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using SharpForum.Models.EntityModels;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpForum.Data.SharpForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SharpForum.Data.SharpForumContext";
        }

        protected override void Seed(SharpForum.Data.SharpForumContext context)
        {
            // Add Roles
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manage = new RoleManager<IdentityRole>(store);

                var adminRole = new IdentityRole("Admin");
                var moderatorRole = new IdentityRole("Moderator");
                var userRole = new IdentityRole("User");

                context.Roles.Add(adminRole);
                context.Roles.Add(moderatorRole);
                context.Roles.Add(userRole);
            }

            // Add Categories
            if (!context.Categories.Any())
            {
                Category homeCategory = new Category()
                {
                    Name = "Home",
                    Description = "Default home category",
                    Priority = 1,
                    IsSuperCategory = true
                };

                Category newsCategory = new Category()
                {
                    Name = "News",
                    Description = "News about the forum",
                    Priority = 2,
                    IsSuperCategory = false
                };

                Category introductionCategory = new Category()
                {
                    Name = "Introduction",
                    Description = "Tell us about yourself",
                    Priority = 3,
                    IsSuperCategory = false
                };

                Category entertainmentCategory = new Category()
                {
                    Name = "Entertainment",
                    Description = "Default entertainment category",
                    Priority = 4,
                    IsSuperCategory = true
                };

                Category moviesCategory = new Category()
                {
                    Name = "Movies",
                    Description = "Discuss movies here",
                    Priority = 5,
                    IsSuperCategory = false
                };

                Category musicCategory = new Category()
                {
                    Name = "Music",
                    Description = "Discuss music here",
                    Priority = 6,
                    IsSuperCategory = false
                };

                context.Categories.Add(homeCategory);
                context.Categories.Add(newsCategory);
                context.Categories.Add(introductionCategory);
                context.Categories.Add(entertainmentCategory);
                context.Categories.Add(moviesCategory);
                context.Categories.Add(musicCategory);

                context.SaveChanges();
            }

            #region Add Users For Testing
            // Add Users
            if (!context.Users.Any())
            {
                var store = new UserStore<User>(context);
                var manager = new UserManager<User>(store);

                User admin = new User()
                {
                    Email = "admin@example.com",
                    UserName = "Admin",
                    AboutMe = "I am example admin.",
                    WebsiteUrl = "http://sharpforum.tk/",
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
                    WebsiteUrl = "http://danielignatov.ml",
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
                    WebsiteUrl = "http://danielignatov.ml/code",
                    AvatarUrl = "../content/avatars/avatar3.png",
                    DateOfRegistration = DateTime.Now,
                    ForumSignature = "User signature",
                    RoleTitle = "User"
                };

                manager.Create(user, "User12");
                manager.AddToRole(user.Id, "User");
            }

            context.SaveChanges();
            #endregion 
        }
    }
}
