namespace SharpForum.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        #region Constructors
        public User()
        {
            this.Topics = new HashSet<Topic>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime DateOfRegistration { get; set; }

        public string AvatarUrl { get; set; }

        public string WebsiteUrl { get; set; }

        public string Signature { get; set; }

        public string LivingLocation { get; set; }

        public virtual UserRole UserRole { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }
        #endregion
    }
}