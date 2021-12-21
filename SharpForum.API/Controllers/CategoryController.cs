using SharpForum.Application.Categories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpForum.Domain;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace SharpForum.API.Controllers
{
    [ApiController]
    public class CategoryController : BaseController
    {
        /// <summary>
        /// Get category by id
        /// </summary>
        /// <param name="id">Category globally unique identifier</param>
        [AllowAnonymous]
        [HttpGet("category/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<Category> Category(Guid id)
        {
            return await Mediator.Send(new CategoryDetails.Query { Id = id });
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        [AllowAnonymous]
        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IEnumerable<Category>> Categories()
        {
            return await Mediator.Send(new CategoryList.Query());
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            return Ok(await Mediator.Send(new CategoryCreate.Command { Category = category }));
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("category/{id}")]
        public async Task<IActionResult> EditCategory(Guid id, Category category)
        {
            category.Id = id;
            return Ok(await Mediator.Send(new CategoryEdit.Command { Category = category }));
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            return Ok(await Mediator.Send(new CategoryDelete.Command { Id = id }));
        }
    }
}
