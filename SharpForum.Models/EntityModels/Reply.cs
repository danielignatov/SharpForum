namespace SharpForum.Models.EntityModels
{
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public virtual User Author { get; set; }
        #endregion
    }
}