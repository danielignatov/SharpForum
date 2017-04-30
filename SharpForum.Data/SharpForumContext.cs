namespace SharpForum.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SharpForum.Models.EntityModels;
    using System.Data.Entity;

    public class SharpForumContext : IdentityDbContext<User>
    {
        public SharpForumContext()
            : base("name=SharpForumContext", throwIfV1Schema: false)
        {
        }

        public static SharpForumContext Create()
        {
            return new SharpForumContext();
        }

        public virtual DbSet<Reply> Replies { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<Category> Categories { get; set; }
    }
}