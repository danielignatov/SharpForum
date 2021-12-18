using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace SharpForum.Domain
{
    /// <summary>
    /// User
    /// </summary>
    public class User : IdentityUser
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
        /// Text under display name
        /// </summary>
        public string Title { get; set; }

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
        public ICollection<Topic> Topics { get; set; }

        /// <summary>
        /// User created replies
        /// </summary>
        public ICollection<Reply> Replies { get; set; }
    }
}