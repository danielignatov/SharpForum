using System.ComponentModel.DataAnnotations;

namespace SharpForum.API.Models.DataTransferObjects.User
{
    /// <summary>
    /// User request request data transfer object
    /// </summary>
    public class UserRegisterDto
    {
        /// <summary>
        /// Display name
        /// </summary>
        [Required]
        public string DisplayName { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}