using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SharpForum.API.Models.Domain
{
    /// <summary>
    /// User role
    /// </summary>
    public class Role
    {
        /// <summary>
        /// Globally unique identifier
        /// </summary>
        [Required]
        public Guid Id { get; set; }

        /// <summary>
        /// Role name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Users assigned with role
        /// </summary>
        public virtual ICollection<User> Users { get; set; }
    }
}