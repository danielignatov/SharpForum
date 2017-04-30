using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpForum.Application;
using SharpForum.Application.Controllers;
using TestStack.FluentMVCTesting;
using SharpForum.Models.ViewModels.User;
using SharpForum.App.Controllers;
using System.Net;
using AutoMapper;
using SharpForum.Services;
using SharpForum.Models.EntityModels;
using SharpForum.Models.ViewModels.Topic;

namespace SharpForum.Application.Tests.Controllers
{
    [TestClass]
    public class TopicControllerTest
    {
        private TopicController _controller;
        private TopicService _service;
        private List<Topic> topics;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Topic, TopicViewModel>()
                    .ForMember(cid => cid.CategoryId,
                    configurationExpression =>
                    configurationExpression.MapFrom(c => c.Category.Id))
                    .ForMember(ct => ct.CategoryName,
                    configurationExpression =>
                    configurationExpression.MapFrom(c => c.Category.Name))
                    .ForMember(ai => ai.AuthorId,
                    configurationExpression =>
                    configurationExpression.MapFrom(a => a.Author.Id))
                    .ForMember(au => au.AuthorUsername,
                    configurationExpression =>
                    configurationExpression.MapFrom(a => a.Author.UserName))
                    .ForMember(rc => rc.RepliesCount,
                    configurationExpression =>
                    configurationExpression.MapFrom(r => r.Replies.Count));
                expression.CreateMap<TopicViewModel, Topic>();
            });
        }

        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.topics = new List<Topic>()
            {
                new Topic()
                {
                    Id = 1,
                    Title = "title",
                    Content = "content",
                    IsLocked = false,
                    IsSticky = false,
                    PublishDate = DateTime.Now
                },
                new Topic()
                {
                    Id = 2,
                    Title = "title2",
                    Content = "content2",
                    IsLocked = false,
                    IsSticky = false,
                    PublishDate = DateTime.Now
                }
            };

            this._service = new TopicService();
            this._controller = new TopicController();
        }

        [TestMethod]
        public void Topic_WithInvalidId_ReturnNotFound()
        {
            TopicController controller = new TopicController();

            controller.WithCallTo(c => c.Topic(10))
                .ShouldGiveHttpStatus(HttpStatusCode.NotFound);
        }
    }
}