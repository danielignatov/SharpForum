namespace SharpForum.Models.ViewModels
{
    using System.Collections.Generic;

    public class TopicRepliesViewModel
    {
        public TopicViewModel Topic { get; set; }

        public IEnumerable<ReplyViewModel> Replies { get; set; }
    }
}