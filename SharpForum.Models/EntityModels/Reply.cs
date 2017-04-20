namespace SharpForum.Models.EntityModels
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Reply
    {
        #region Properties
        [Key]
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual User Author { get; set; }

        public virtual Topic Topic { get; set; }
        #endregion
    }
}