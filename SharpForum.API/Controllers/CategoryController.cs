using SharpForum.Application.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpForum.Domain;

namespace SharpForum.API.Controllers
{
    [ApiController]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">Category id</param>
        [AllowAnonymous]
        [HttpGet("api/category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Category> Category(Guid id)
        {
            return await Mediator.Send(new Details.Query { Id = id });
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        [AllowAnonymous]
        [HttpGet("api/categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Category>> Categories()
        {
            return await Mediator.Send(new List.Query());
        }
    }
}
