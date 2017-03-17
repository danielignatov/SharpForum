using AutoMapper;
using SharpForum.Models.EntityModels;
using SharpForum.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SharpForum.App
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            this.RegisterMaps();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
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
                    .ForMember(ai => ai.AuthorId,
                    configurationExpression =>
                    configurationExpression.MapFrom(a => a.Author.Id))
                    .ForMember(au => au.AuthorUsername,
                    configurationExpression =>
                    configurationExpression.MapFrom(a => a.Author.Username))
                    .ForMember(rc => rc.RepliesCount,
                    configurationExpression =>
                    configurationExpression.MapFrom(r => r.Replies.Count));
                expression.CreateMap<User, UserViewModel>();
                expression.CreateMap<Reply, ReplyViewModel>();
            });
        }
    }
}
