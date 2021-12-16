namespace SharpForum.Data
{
    using System.Data.Entity;

    public class DatabaseInitializer : CreateDatabaseIfNotExists<SharpForumContext>
    {
        protected override void Seed(SharpForumContext context)
        {
            SeedValues.Roles(context);
            SeedValues.Categories(context);
            SeedValues.Users(context);

            base.Seed(context);
        }
    }
}