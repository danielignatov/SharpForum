using System;
using System.ComponentModel.DataAnnotations;

namespace SharpForum.API.Models.Domain
{
    /// <summary>
    /// Base entity class
    /// </summary>
    public abstract class Entity
    {
        /// <summary>
        /// Globally unique identifier
        /// </summary>
        [Required]
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Creation date and time (UTC)
        /// </summary>
        public virtual DateTime CreatedOn { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Last updated date and time (UTC)
        /// </summary>
        public virtual DateTime UpdatedOn { get; set; } = DateTime.UtcNow;

        /// <summary>
        /// Is considered as removed
        /// </summary>
        public virtual bool Removed { get; set; }
    }
}