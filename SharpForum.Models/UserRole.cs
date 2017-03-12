namespace SharpForum.Models
{
    using System.ComponentModel.DataAnnotations;

    public class UserRole
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public bool CanAccessAdminPanel { get; set; }

        public bool CanModerateTopics { get; set; }
        #endregion
    }
}