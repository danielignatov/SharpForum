namespace SharpForum.Data.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<SharpForumContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
            ContextKey = "SharpForum.Data.SharpForumContext";
        }

        protected override void Seed(SharpForumContext context)
        {
            SeedValues.Roles(context);
            SeedValues.Categories(context);
            SeedValues.Users(context);
        }
    }
}