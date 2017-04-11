namespace SharpForum.Models.ViewModels
{
    using System.Collections.Generic;

    public class TopicAuthorRepliesAuthorsViewModel
    {
        public TopicViewModel Topic { get; set; }

        public UserViewModel Author { get; set; }

        public IEnumerable<ReplyAuthorViewModel> Replies { get; set; }
    }
}