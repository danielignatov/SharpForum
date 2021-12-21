using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SharpForum.API.DataTransferObjects.User;

namespace SharpForum.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {
        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="id">User id</param>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> User(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="userLoginDto"></param>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            throw new NotImplementedException();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(UserRegisterDto userRegisterDto)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Topics created by user
        /// </summary>
        /// <param name="id">User id</param>
        [AllowAnonymous]
        [HttpGet("{id}/topics")]
        public async Task<IActionResult> Topics(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Replies created by user
        /// </summary>
        /// <param name="id">User id</param>
        [AllowAnonymous]
        [HttpGet("{id}/replies")]
        public async Task<IActionResult> Replies(string id)
        {
            throw new NotImplementedException();
        }
    }
}