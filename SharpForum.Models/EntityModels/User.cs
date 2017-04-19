namespace SharpForum.Models.EntityModels
{
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.ComponentModel;

    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class User : IdentityUser
    {
        #region Constructors
        public User()
        {
            this.Topics = new HashSet<Topic>();
            this.Replies = new HashSet<Reply>();
        }
        #endregion

        public DateTime DateOfRegistration { get; set; }

        public string RoleTitle { get; set; }
        
        public string AvatarUrl { get; set; }

        public string WebsiteUrl { get; set; }

        public string AboutMe { get; set; }

        public string LivingLocation { get; set; }

        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        public string ForumSignature { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}