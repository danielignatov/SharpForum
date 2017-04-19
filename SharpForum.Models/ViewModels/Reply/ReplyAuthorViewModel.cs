namespace SharpForum.Models.ViewModels.Reply
{
    using SharpForum.Models.ViewModels.Topic;
    using SharpForum.Models.ViewModels.User;

    public class ReplyAuthorViewModel
    {
        public ReplyViewModel Reply { get; set; }

        public UserViewModel Author { get; set; }
    }
}