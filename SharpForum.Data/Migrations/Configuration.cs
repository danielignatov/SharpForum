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
            if(!context.Roles.Any())
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
                    Description = "Tell us more about yourself",
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
            }
        }
    }
}
