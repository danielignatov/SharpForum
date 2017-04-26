using AutoMapper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SharpForum.Application.Controllers;
using SharpForum.Data;
using SharpForum.Models.EntityModels;
using SharpForum.Models.ViewModels;
using SharpForum.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharpForum.Application.Tests.Controllers
{
    [TestClass]
    public class CategoryControllerTest
    {
        private CategoryController _controller;
        private CategoryService _service;
        private SharpForumContext _context;
        private List<Category> categories;

        private void ConfigureMapper()
        {
            Mapper.Initialize(expression =>
            {
                expression.CreateMap<Category, CategoryViewModel>();
                expression.CreateMap<CategoryViewModel, Category>();
            });
        }

        //[TestInitialize]
        //public void Init()
        //{
        //    this.ConfigureMapper();
        //    this.categories = new List<Category>()
        //    {
        //        new Category()
        //        {
        //            Id = 1,
        //            Name = "NewsTest",
        //            Description = null,
        //            IsSuperCategory = true,
        //            Priority = 1
        //        },
        //        new Category()
        //        {
        //            Id = 2,
        //            Name = "CategoryTest",
        //            Description = "Desc",
        //            IsSuperCategory = false,
        //            Priority = 2
        //        }
        //    };
        //
        //    this._context = new FakeCarsDbContext();
        //    foreach (var category in categories)
        //    {
        //        this._context.Categories.Add(category);
        //    }
        //
        //    HttpConfiguration config = new HttpConfiguration();
        //    this._service = new CarsService(this._context);
        //    this._controller = new CarsController(this._service);
        //    this._controller.Configuration = config;
        //}
        //
        //[TestMethod]
        //public void ListAllCars_ShouldReturnOk()
        //{
        //    var data = this._controller.Get() as OkNegotiatedContentResult<IEnumerable<CarVm>>;
        //    Assert.IsNotNull(data);
        //}
        //
        //[TestMethod]
        //public void ListAllCars_ShouldReturnGivenCars()
        //{
        //    var data = this._controller.Get() as OkNegotiatedContentResult<IEnumerable<CarVm>>;
        //    Assert.AreEqual(2, data.Content.Count());
        //}
        //
        //[TestMethod]
        //public void GetValidCarById_ShouldReturnOk()
        //{
        //    var data = this._controller.Get(1) as OkNegotiatedContentResult<CarVm>;
        //    Assert.IsNotNull(data);
        //}
        //
        //[TestMethod]
        //public void GetValidCarById_ShouldReturnGivenCar()
        //{
        //    var data = this._controller.Get(1) as OkNegotiatedContentResult<CarVm>;
        //    Assert.AreEqual(20, data.Content.Price);
        //    Assert.AreEqual("Volga", data.Content.Name);
        //}
        //
        //[TestMethod]
        //public void GetInValidCarById_ShouldNotFound()
        //{
        //    var data = this._controller.Get(3) as NotFoundResult;
        //    Assert.IsNotNull(data);
        //}
        //
        //[TestMethod]
        //public void PostValidCar_ShouldReturnCreated()
        //{
        //    CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
        //    var data = this._controller.Post(testCar) as StatusCodeResult;
        //    Assert.AreEqual(HttpStatusCode.Created, data.StatusCode);
        //}
        //
        //[TestMethod]
        //public void PostValidCar_ShouldAddToRepo()
        //{
        //    CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
        //    var data = this._controller.Post(testCar) as StatusCodeResult;
        //    Assert.AreEqual(3, this._context.Cars.Count());
        //}
        //
        //[TestMethod]
        //public void PostInValidCar_ShouldReturnBadRequest()
        //{
        //    CarBm testCar = new CarBm() { Name = "Ta", Price = 15 };
        //    this._controller.Validate(testCar);
        //    var data = this._controller.Post(testCar) as StatusCodeResult;
        //    Assert.AreEqual(HttpStatusCode.BadRequest, data.StatusCode);
        //}
        //
        //[TestMethod]
        //public void PutValidCar_ShouldReturnNoContent()
        //{
        //    CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
        //    var data = this._controller.Put(1, testCar) as StatusCodeResult;
        //    Assert.AreEqual(HttpStatusCode.NoContent, data.StatusCode);
        //}
        //
        //[TestMethod]
        //public void PutValidCar_ShouldModifyCar()
        //{
        //    CarBm testCar = new CarBm() { Name = "Trabant", Price = 15 };
        //    var data = this._controller.Put(1, testCar) as StatusCodeResult;
        //    Assert.AreEqual("Trabant", this.cars[0].Name);
        //    Assert.AreEqual(15, this.cars[0].Price);
        //}
        //
        //[TestMethod]
        //public void PutInvalidCar_ShouldReturnBadRequest()
        //{
        //    CarBm testCar = new CarBm() { Name = "Go", Price = 15 };
        //    this._controller.Validate(testCar);
        //    var data = this._controller.Put(1, testCar) as StatusCodeResult;
        //    Assert.AreEqual(HttpStatusCode.BadRequest, data.StatusCode);
        //}
        //
        //[TestMethod]
        //public void PutValidCarOnInvalidId_ShouldReturnNotFound()
        //{
        //    CarBm testCar = new CarBm() { Name = "BMW", Price = 15 };
        //    var data = this._controller.Put(3, testCar) as StatusCodeResult;
        //    Assert.AreEqual(HttpStatusCode.NotFound, data.StatusCode);
        //}
        //
        //[TestMethod]
        //public void DeleteExistingCar_ShouldReturnOk()
        //{
        //    var data = this._controller.Delete(2) as OkResult;
        //    Assert.IsNotNull(data);
        //}
        //
        //[TestMethod]
        //public void DeleteExistingCar_ShouldDeleteCarFromRepo()
        //{
        //    var data = this._controller.Delete(2) as OkResult;
        //    Assert.AreEqual(1, this._context.Cars.Count());
        //}
        //
        //[TestMethod]
        //public void DeleteNonExistingCar_ShouldReturnNoFound()
        //{
        //    var data = this._controller.Delete(3) as StatusCodeResult;
        //    Assert.AreEqual(HttpStatusCode.NotFound, data.StatusCode);
        //}

        [TestMethod]
        public void All()
        {
            // Arrange
            //HomeController controller = new HomeController();

            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }

        [TestMethod]
        public void Category()
        {
            // Arrange
            //HomeController controller = new HomeController();

            // Act
            //ViewResult result = controller.Index() as ViewResult;

            // Assert
            //Assert.IsNotNull(result);
        }
    }
}
