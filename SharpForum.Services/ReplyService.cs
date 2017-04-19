namespace SharpForum.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using SharpForum.Models.ViewModels.Reply;
    using SharpForum.Models.EntityModels;
    using AutoMapper;

    public class ReplyService : Service
    {
        public void AddNewReply(ReplyViewModel model, int topicId, string userId)
        {
            Reply newReply = Mapper.Instance.Map<ReplyViewModel, Reply>(model);
            Topic currentTopic = this.Context.Topics.Find(topicId);
            User currentAuthor = this.Context.Users.Find(userId);

            newReply.Author = currentAuthor;
            newReply.PublishDate = DateTime.Now;

            currentTopic.Replies.Add(newReply);
            this.Context.SaveChanges();
        }
    }
}