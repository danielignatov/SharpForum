namespace SharpForum.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
        }
    }
}
