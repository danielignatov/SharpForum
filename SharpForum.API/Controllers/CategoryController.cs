using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using SharpForum.API.Models.Domain;

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
        public async Task<IActionResult> Category(Guid id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all categories
        /// </summary>
        [AllowAnonymous]
        [HttpGet("categories")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Categories()
        {
            throw new NotImplementedException();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost("category/create")]
        public async Task<IActionResult> CreateCategory(Category category)
        {
            throw new NotImplementedException();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPut("category/{id}")]
        public async Task<IActionResult> EditCategory(Guid id, Category category)
        {
            category.Id = id;
            throw new NotImplementedException();
        }

        //[Authorize(Roles = "Admin")]
        [HttpDelete("category/{id}")]
        public async Task<IActionResult> DeleteActivity(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
