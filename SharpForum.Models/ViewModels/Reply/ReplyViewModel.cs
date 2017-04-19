namespace SharpForum.Models.ViewModels.Reply
{
    using System;

    public class ReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        // Custom view properties

        public int TopicId { get; set; }
    }
}