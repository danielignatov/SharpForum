using System.ComponentModel.DataAnnotations;

namespace SharpForum.API.Models.DataTransferObjects.User
{
    /// <summary>
    /// User login request data transfer object
    /// </summary>
    public class UserLoginDto
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        public string Password { get; set; }
    }
}