namespace SharpForum.API.DataTransferObjects.User
{
    /// <summary>
    /// User data transer object
    /// </summary>
    public class UserDto
    {
        /// <summary>
        /// Globally unique identifier
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// User display name
        /// </summary>
        public string DisplayName { get; set; }

        /// <summary>
        /// User email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// JSON Web Token
        /// </summary>
        public string Token { get; set; }
    }
}