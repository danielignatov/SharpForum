namespace SharpForum.Models.ViewModels
{
    using System;

    public class ReplyViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }
    }
}