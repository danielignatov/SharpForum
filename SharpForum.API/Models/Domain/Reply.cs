using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SharpForum.API.Models.Domain
{
    /// <summary>
    /// Topic reply
    /// </summary>
    public class Reply : Entity
    {
        public Reply()
        {
            Message = string.Empty;
        }

        /// <summary>
        /// Message body
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Author identifier
        /// </summary>
        public Guid AuthorId { get; set; }

        /// <summary>
        /// Author of the reply
        /// </summary>
        public virtual User Author { get; set; }

        /// <summary>
        /// Related topic identifier
        /// </summary>
        [Required]
        public Guid TopicId { get; set; }

        /// <summary>
        /// Related topic
        /// </summary>
        public virtual Topic Topic { get; set; }
    }
}