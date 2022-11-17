using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        /// Topic author identifier
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Topic author
        /// </summary>
        public virtual User Author { get; set; }

        /// <summary>
        /// Topic replies
        /// </summary>
        public virtual ICollection<Reply> Replies { get; set; }

        /// <summary>
        /// Topic category identifier
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Topic category
        /// </summary>
        public virtual Category Category { get; set; }
    }
}