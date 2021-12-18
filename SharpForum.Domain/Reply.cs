namespace SharpForum.Domain
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
        /// Author of the reply
        /// </summary>
        public User Author { get; set; }

        /// <summary>
        /// Related topic
        /// </summary>
        public Topic Topic { get; set; }
    }
}