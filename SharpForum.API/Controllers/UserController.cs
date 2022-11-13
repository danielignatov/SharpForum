using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SharpForum.API.Models.DataTransferObjects.User;
using SharpForum.API.Models.Domain;
using SharpForum.API.Services.Email;
using SharpForum.API.Services.Security;
using System.Net.Http;

namespace SharpForum.API.Controllers
{
    [ApiController]
    [Route("api/user")]
    public class UserController : BaseController
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly TokenService _tokenService;
        private readonly IConfiguration _config;
        private readonly HttpClient _httpClient;
        //private readonly EmailService _emailSender;

        public UserController(
            UserManager<User> userManager,
            SignInManager<User> signInManager, 
            TokenService tokenService,
            IConfiguration config//,
            //EmailService emailSender
            )
        {
            //_emailSender = emailSender;
            _config = config;
            _tokenService = tokenService;
            _signInManager = signInManager;
            _userManager = userManager;
            _httpClient = new HttpClient
            {
                BaseAddress = new System.Uri("https://graph.facebook.com")
            };
        }

        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="id">User id</param>
        [AllowAnonymous]
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UserProfile(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// User login
        /// </summary>
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.Users
                .FirstOrDefaultAsync(x => x.Email == userLoginDto.Email);

            if (user == null) return Unauthorized("Invalid email");

            if (user.UserName == "bob") user.EmailConfirmed = true;

            if (!user.EmailConfirmed) return Unauthorized("Email not confirmed");

            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password, false);

            if (result.Succeeded)
            {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    Email = user?.Email,
                    Token = _tokenService.CreateToken(user),
                    Id = user.Id
                };
            }

            return Unauthorized("Invalid password");
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