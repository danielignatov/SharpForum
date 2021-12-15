namespace SharpForum.Application.Tests.Controllers
{
    using AutoMapper;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SharpForum.Application.Controllers;
    using System.Net;
    using SharpForum.Models.EntityModels;
    using SharpForum.Models.ViewModels;
    using SharpForum.Services;
    using System.Collections.Generic;
    using TestStack.FluentMVCTesting;

    [TestClass]
    public class CategoryControllerTest
    {
        private CategoryController _controller;
        private CategoryService _service;
        private List<Category> categories;
        
        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Category, CategoryViewModel>();
                expression.CreateMap<CategoryViewModel, Category>();
            });
        }
        
        [TestInitialize]
        public void Init()
        {
            this.ConfigureMapper();
            this.categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "NewsTest",
                    Description = null,
                    IsCategoryPlaceholder = true,
                    Priority = 1
                },
                new Category()
                {
                    Id = 2,
                    Name = "CategoryTest",
                    Description = "Desc",
                    IsCategoryPlaceholder = false,
                    Priority = 2
                }
            };
        
            this._service = new CategoryService();
            this._controller = new CategoryController();
        }

        [TestMethod]
        public void All_ReturnViewResult_ShouldPass()
        {
            CategoryController controller = new CategoryController();

            controller.WithCallTo(c => c.All())
                .ShouldRenderDefaultView()
                .WithModel<IList<CategoryViewModel>>();
        }
    }
}
