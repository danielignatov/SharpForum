namespace SharpForum.Models.ViewModels.Reply
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class ReplyViewModel
    {
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        // Custom view properties

        public int TopicId { get; set; }
    }
}