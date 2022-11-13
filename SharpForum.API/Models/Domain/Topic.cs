using System.Collections.Generic;

namespace SharpForum.API.Models.Domain
{
    /// <summary>
    /// Topic
    /// </summary>
    public class Topic : Entity
    {
        public Topic()
        {
            Subject = string.Empty;
            Message = string.Empty;
            Replies = new HashSet<Reply>();
        }

        /// <summary>
        /// Topic subject
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// Message body
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Topic should be displayed on top
        /// </summary>
        public bool Sticky { get; set; }

        /// <summary>
        /// Topic is closed for new replies
        /// </summary>
        public bool Locked { get; set; }

        /// <summary>
        /// Topic author
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Topic replies
        /// </summary>
        public ICollection<Reply> Replies { get; set; }
    }
}