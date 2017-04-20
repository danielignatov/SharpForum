using AutoMapper;
using SharpForum.Models.EntityModels;
using SharpForum.Models.ViewModels;
using SharpForum.Models.ViewModels.Reply;
using SharpForum.Models.ViewModels.Topic;
using SharpForum.Models.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SharpForum.Application
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            AreaRegistration.RegisterAllAreas();
            this.RegisterMaps();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterMaps()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Category, CategoryViewModel>()
                    .ForMember(tc => tc.TopicsCount,
                    configurationExpression =>
                    configurationExpression.MapFrom(t => t.Topics.Count))
                    .ForMember(rc => rc.RepliesCount,
                    configurationExpression =>
                    configurationExpression.MapFrom(r => r.Topics.Sum(re => re.Replies.Count)));
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
                expression.CreateMap<User, UserViewModel>()
                    .ForMember(tmc => tmc.TotalMessagesCount,
                    configurationExpression =>
                    configurationExpression.MapFrom(u => u.Topics.Count() + u.Replies.Count()));
                expression.CreateMap<Reply, ReplyViewModel>()
                    .ForMember(tid => tid.TopicId,
                    configurationExpression =>
                    configurationExpression.MapFrom(u => u.Topic.Id));
                expression.CreateMap<ReplyViewModel, Reply>();
                    
            });
        }
    }
}
