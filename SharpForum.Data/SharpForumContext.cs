namespace SharpForum.Data
{
    using SharpForum.Models;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SharpForumContext : DbContext
    {
        #region Constructors
        // Your context has been configured to use a 'SharpForumContext' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'SharpForum.Data.SharpForumContext' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'SharpForumContext' 
        // connection string in the application configuration file.
        public SharpForumContext()
            : base("name=SharpForumContext")
        {
        }
        #endregion

        #region Properties
        public virtual DbSet<Reply> Replies { get; set; }

        public virtual DbSet<Topic> Topics { get; set; }

        public virtual DbSet<UserRole> UserRoles { get; set; }

        public virtual DbSet<User> Users { get; set; }
        #endregion
    }
}