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

        public ReplyViewModel GetReplyViewModel(int? replyId)
        {
            Reply reply = this.Context.Replies.Find(replyId);
            ReplyViewModel rvm = Mapper.Instance.Map<Reply, ReplyViewModel>(reply);
            rvm.TopicId = reply.Topic.Id;

            return rvm;
        }

        public void EditReply(ReplyViewModel model)
        {
            Reply reply = this.Context.Replies.Find(model.Id);
            reply.Content = model.Content;

            this.Context.SaveChanges();
        }

        public void DeleteReply(int? replyId)
        {
            this.Context.Replies.Remove(this.Context.Replies.Find(replyId));
            this.Context.SaveChanges();
        }
    }
}