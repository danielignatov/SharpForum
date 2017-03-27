namespace SharpForum.Models.EntityModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class ForumUser
    {
        #region Constructors
        public ForumUser()
        {
            this.Topics = new HashSet<Topic>();
            this.Replies = new HashSet<Reply>();
        }
        #endregion

        #region Properties
        [Key]
        public int Id { get; set; }

        public string ForumSignature { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ICollection<Topic> Topics { get; set; }

        public virtual ICollection<Reply> Replies { get; set; }
        #endregion
    }
}