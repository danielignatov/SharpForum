namespace SharpForum.Services
{
    using AutoMapper;
    using SharpForum.Models.EntityModels;
    using SharpForum.Models.ViewModels;
    using System.Collections.Generic;
    using System;
    using System.Linq;

    public class TopicsService : Service
    {
        public TopicAuthorRepliesAuthorsViewModel GetTopic(int id)
        {
            Topic topic = this.Context.Topics.Find(id);

            TopicViewModel topicViewModel = Mapper.Instance.Map<Topic, TopicViewModel>(topic);
            UserViewModel topicAuthorUserViewModel = Mapper.Instance.Map<User, UserViewModel>(topic.Author);

            List<ReplyAuthorViewModel> replyAuthorViewModelList = new List<ReplyAuthorViewModel>();

            foreach (var reply in topic.Replies)
            {
                ReplyViewModel replyViewModel = Mapper.Instance.Map<Reply, ReplyViewModel>(reply);
                UserViewModel replyAuthorUserViewModel = Mapper.Instance.Map<User, UserViewModel>(reply.Author);

                ReplyAuthorViewModel replyAuthorViewModel = new ReplyAuthorViewModel()
                {
                    Reply = replyViewModel,
                    Author = replyAuthorUserViewModel
                };

                replyAuthorViewModelList.Add(replyAuthorViewModel);
            }

            IEnumerable<ReplyAuthorViewModel> replyAuthorViewModels = replyAuthorViewModelList;

            TopicAuthorRepliesAuthorsViewModel topicAuthorRepliesAuthorsViewModel = new TopicAuthorRepliesAuthorsViewModel()
            {
                Topic = topicViewModel,
                Author = topicAuthorUserViewModel,
                Replies = replyAuthorViewModels
            };

            return topicAuthorRepliesAuthorsViewModel;
        }

        public bool DoesTopicExist(int id)
        {
            throw new NotImplementedException();
        }
    }
}