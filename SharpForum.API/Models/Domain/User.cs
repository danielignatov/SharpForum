using System.Collections.Generic;

namespace SharpForum.API.Models.Domain
{
    /// <summary>
    /// User
    /// </summary>
    public class User : Entity
    {
        public User()
        {
            Topics = new HashSet<Topic>();
            Replies = new HashSet<Reply>();
        }

        /// <summary>
        /// Display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// Avatar image url
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// User disclosed info about themself
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// User website url
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// User disclosed location
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Piece of text appended in user topics and replies
        /// </summary>
        public string Signature { get; set; }

        /// <summary>
        /// User created topics
        /// </summary>
        public virtual ICollection<Topic> Topics { get; set; }

        /// <summary>
        /// User created replies
        /// </summary>
        public virtual ICollection<Reply> Replies { get; set; }

        /// <summary>
        /// User hashed password
        /// </summary>
        public string PasswordHash { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// User role identifier
        /// </summary>
        public Guid RoleId { get; set; }

        /// <summary>
        /// User role
        /// </summary>
        public virtual Role Role { get; set; }
    }
}