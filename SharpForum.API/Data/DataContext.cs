using Microsoft.EntityFrameworkCore;
using SharpForum.API.Models.Domain;

namespace SharpForum.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Topic> Topics { get; set; }

        public DbSet<Reply> Replies { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Role>(entity =>
            {
                entity.Property(x => x.Id)
                    .IsRequired();
            });

            builder.Entity<User>(entity =>
            {
                entity.Property(x => x.Id)
                    .IsRequired();

                entity.HasOne(x => x.Role)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");
            });
            
            builder.Entity<Category>(entity =>
            {
                entity.Property(x => x.Id)
                    .IsRequired();
            });
            
            builder.Entity<Topic>(entity =>
            {
                entity.Property(x => x.Id)
                    .IsRequired();

                entity.HasOne(x => x.Author)
                    .WithMany(x => x.Topics)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topic_Author");

                entity.HasOne(x => x.Category)
                    .WithMany(x => x.Topics)
                    .HasForeignKey(x => x.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Topic_Category");
            });
            
            builder.Entity<Reply>(entity =>
            {
                entity.Property(x => x.Id)
                    .IsRequired();

                entity.HasOne(x => x.Topic)
                    .WithMany(x => x.Replies)
                    .HasForeignKey(x => x.TopicId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Topic");

                entity.HasOne(x => x.Author)
                    .WithMany(x => x.Replies)
                    .HasForeignKey(x => x.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Reply_Author");
            });
        }
    }
}