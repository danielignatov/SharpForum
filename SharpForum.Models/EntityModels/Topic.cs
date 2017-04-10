namespace SharpForum.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Topic
    {
        #region Constructors
        public Topic()
        {
            this.Replies = new HashSet<Reply>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public bool IsSticky { get; set; }

        public bool IsLocked { get; set; }

        public DateTime PublishDate { get; set; }

        public virtual User Author { get; set; }
        
        public virtual ICollection<Reply> Replies { get; set; }
        #endregion
    }
}