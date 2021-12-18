﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharpForum.API.DataTransferObjects.User;

namespace SharpForum.API.Controllers
{
    [ApiController]
    public class UserController : BaseController
    {
        /// <summary>
        /// Get user profile
        /// </summary>
        /// <param name="id">User id</param>
        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> User(string id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// User login
        /// </summary>
        /// <param name="userLoginDto"></param>
        /// <returns></returns>
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