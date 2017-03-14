namespace SharpForum.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }
        #endregion
    }
}