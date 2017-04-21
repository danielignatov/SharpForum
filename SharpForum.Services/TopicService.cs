namespace SharpForum.Services
{
    using AutoMapper;
    using SharpForum.Models.EntityModels;
    using SharpForum.Models.ViewModels;
    using System.Collections.Generic;
    using System;
    using System.Linq;
    using SharpForum.Models.ViewModels.Topic;
    using SharpForum.Models.ViewModels.User;
    using SharpForum.Models.ViewModels.Reply;
    using SharpForum.Models.Attributes;

    public class TopicService : Service
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

        public void DeleteTopic(int? topicId)
        {
            this.Context.Topics.Remove(this.Context.Topics.Find(topicId));

            this.Context.SaveChanges();
        }

        public void LockTopic(int? topicId)
        {
            Topic topic = this.Context.Topics.Find(topicId);
            topic.IsLocked = true;

            this.Context.SaveChanges();
        }

        public void EditTopic(TopicViewModel model)
        {
            Topic topic = this.Context.Topics.Find(model.Id);
            topic.Content = model.Content;
            topic.Title = model.Title;

            this.Context.SaveChanges();
        }

        public void UnlockTopic(int? topicId)
        {
            Topic topic = this.Context.Topics.Find(topicId);
            topic.IsLocked = false;

            this.Context.SaveChanges();
        }

        public TopicViewModel GetTopicViewModel(int? topicId)
        {
            Topic topic = this.Context.Topics.Find(topicId);
            TopicViewModel tvm = Mapper.Map<Topic, TopicViewModel>(topic);

            return tvm;
        }

        public void StickTopic(int? topicId)
        {
            Topic topic = this.Context.Topics.Find(topicId);
            topic.IsSticky = true;

            this.Context.SaveChanges();
        }

        public int GetTopicId(string topicTitle, string topicContent)
        {
            int topicId = this.Context.Topics.Where(t => t.Title == topicTitle && t.Content == topicContent).Select(x => x.Id).FirstOrDefault();

            return topicId;
        }

        public void UnstickTopic(int? topicId)
        {
            Topic topic = this.Context.Topics.Find(topicId);
            topic.IsSticky = false;

            this.Context.SaveChanges();
        }

        public bool DoesTopicExist(int id)
        {
            // todo

            return true;
        }

        public void AddNewTopic(TopicViewModel model, int categoryId, string userId)
        {
            Topic topic = Mapper.Instance.Map<TopicViewModel, Topic>(model);
            Category currentCategory = this.Context.Categories.Find(categoryId);
            User currentAuthor = this.Context.Users.Find(userId);
            
            topic.PublishDate = DateTime.Now;
            topic.Author = currentAuthor;
            topic.Category = currentCategory;

            this.Context.Topics.Add(topic);
            this.Context.SaveChanges();
        }

        public ShowTopicsAuthorsRepliesAuthorsViewModel GetSearchedTopicsViewModel(string searchTerm, bool? includeContent, bool? includeReplies, int? pageId)
        {
            ShowTopicsAuthorsRepliesAuthorsViewModel staravm = new ShowTopicsAuthorsRepliesAuthorsViewModel();

            // No searched topics
            if (searchTerm == null)
            {
                return staravm;
            }
            // Does need to process topics
            else
            {
                
                List<TopicAuthorRepliesAuthorsViewModel> taravml = new List<TopicAuthorRepliesAuthorsViewModel>();
                List<Topic> allTopicsList = this.Context.Topics.OrderBy(tid => tid.Id).ToList();
                List<Topic> sortedTopicsList = new List<Topic>();
                searchTerm = searchTerm.ToLower();

                // dont include content in search
                if ((includeContent == null) || (includeContent == false))
                {
                    // dont include content in search AND dont include replies in search
                    if ((includeReplies == null) || (includeReplies == false))
                    {
                        sortedTopicsList = allTopicsList.Where(t => t.Title.ToLower().Contains(searchTerm.ToLower())).ToList();
                    }
                    // dont include content in search BUT include replies in search
                    else
                    {
                        sortedTopicsList = allTopicsList.Where(t => t.Title.ToLower().Contains(searchTerm) || t.Replies.Any(rc => rc.Content.ToLower().Contains(searchTerm))).ToList();
                    }
                }
                // include content in search
                else
                {
                    // include content in search BUT dont include replies in search
                    if ((includeReplies == null) || (includeReplies == false))
                    {
                        sortedTopicsList = allTopicsList.Where(t => t.Title.ToLower().Contains(searchTerm) || t.Content.ToLower().Contains(searchTerm)).ToList();
                    }
                    // include content in search AND include replies in search
                    else
                    {
                        sortedTopicsList = allTopicsList.Where(t => t.Title.ToLower().Contains(searchTerm) || t.Content.ToLower().Contains(searchTerm) || t.Replies.Any(rc => rc.Content.ToLower().Contains(searchTerm))).ToList();
                    }
                }

                if (pageId == null)
                {
                    staravm.Pagination = new Pagination(taravml.Count(), 1);

                    foreach (var topic in sortedTopicsList.Take(10))
                    {
                        TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                        taravml.Add(taravm);
                    }

                    staravm.Topics = taravml;
                }
                else
                {
                    staravm.Pagination = new Pagination(taravml.Count(), (int)pageId);

                    foreach (var topic in sortedTopicsList.Skip((staravm.Pagination.CurrentPage - 1) * staravm.Pagination.PageSize).Take(staravm.Pagination.PageSize))
                    {
                        TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                        taravml.Add(taravm);
                    }

                    staravm.Topics = taravml;
                }

                return staravm;
            }
        }

        public ShowTopicsAuthorsRepliesAuthorsViewModel GetLatestTopicsInWhichUserHasRepliesViewModel(string userId, int? pageId)
        {
            ShowTopicsAuthorsRepliesAuthorsViewModel staravm = new ShowTopicsAuthorsRepliesAuthorsViewModel();
            List<TopicAuthorRepliesAuthorsViewModel> taravml = new List<TopicAuthorRepliesAuthorsViewModel>();
            List<Topic> sortedTopicsList = this.Context.Topics.OrderByDescending(tpd => tpd.PublishDate).Where(r => r.Replies.Any(auid => auid.Author.Id == userId)).ToList();

            if (pageId == null)
            {
                staravm.Pagination = new Pagination(taravml.Count(), 1);

                foreach (var topic in sortedTopicsList.Take(10))
                {
                    TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                    taravml.Add(taravm);
                }

                staravm.Topics = taravml;
            }
            else
            {
                staravm.Pagination = new Pagination(taravml.Count(), (int)pageId);

                foreach (var topic in sortedTopicsList.Skip((staravm.Pagination.CurrentPage - 1) * staravm.Pagination.PageSize).Take(staravm.Pagination.PageSize))
                {
                    TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                    taravml.Add(taravm);
                }

                staravm.Topics = taravml;
            }

            return staravm;
        }

        public ShowTopicsAuthorsRepliesAuthorsViewModel GetLatestTopicsByUserViewModel(string userId, int? pageId)
        {
            ShowTopicsAuthorsRepliesAuthorsViewModel staravm = new ShowTopicsAuthorsRepliesAuthorsViewModel();
            List<TopicAuthorRepliesAuthorsViewModel> taravml = new List<TopicAuthorRepliesAuthorsViewModel>();
            List<Topic> sortedTopicsList = this.Context.Topics.OrderByDescending(tpd => tpd.PublishDate).Where(auid => auid.Author.Id == userId).ToList();

            if (pageId == null)
            {
                staravm.Pagination = new Pagination(taravml.Count(), 1);

                foreach (var topic in sortedTopicsList.Take(10))
                {
                    TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                    taravml.Add(taravm);
                }

                staravm.Topics = taravml;
            }
            else
            {
                staravm.Pagination = new Pagination(taravml.Count(), (int)pageId);

                foreach (var topic in sortedTopicsList.Skip((staravm.Pagination.CurrentPage - 1) * staravm.Pagination.PageSize).Take(staravm.Pagination.PageSize))
                {
                    TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                    taravml.Add(taravm);
                }

                staravm.Topics = taravml;
            }

            return staravm;
        }

        public ShowTopicsAuthorsRepliesAuthorsViewModel GetLatestTopicsViewModel(int? pageId)
        {
            ShowTopicsAuthorsRepliesAuthorsViewModel staravm = new ShowTopicsAuthorsRepliesAuthorsViewModel();
            List<TopicAuthorRepliesAuthorsViewModel> taravml = new List<TopicAuthorRepliesAuthorsViewModel>();
            List<Topic> sortedTopicsList = this.Context.Topics.OrderByDescending(tpd => tpd.PublishDate).Take(100).ToList();
            
            if (pageId == null)
            {
                staravm.Pagination = new Pagination(taravml.Count(), 1);

                foreach (var topic in sortedTopicsList.Take(10))
                {
                    TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                    taravml.Add(taravm);
                }

                staravm.Topics = taravml;
            }
            else
            {
                staravm.Pagination = new Pagination(taravml.Count(), (int)pageId);

                foreach (var topic in sortedTopicsList.Skip((staravm.Pagination.CurrentPage - 1) * staravm.Pagination.PageSize).Take(staravm.Pagination.PageSize))
                {
                    TopicAuthorRepliesAuthorsViewModel taravm = GetTopic(topic.Id);
                    taravml.Add(taravm);
                }

                staravm.Topics = taravml;
            }

            return staravm;
        }
    }
}