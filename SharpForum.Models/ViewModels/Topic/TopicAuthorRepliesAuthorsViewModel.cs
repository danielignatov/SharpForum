namespace SharpForum.Models.ViewModels.Topic
{
    using SharpForum.Models.Attributes;
    using SharpForum.Models.ViewModels.Reply;
    using SharpForum.Models.ViewModels.User;
    using System.Collections.Generic;

    public class TopicAuthorRepliesAuthorsViewModel
    {
        public TopicViewModel Topic { get; set; }

        public UserViewModel Author { get; set; }

        public IEnumerable<ReplyAuthorViewModel> Replies { get; set; }

        public Pagination Pagination { get; set; }
    }
}