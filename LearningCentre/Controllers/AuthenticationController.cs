using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using LearningCentre.Database;
using LearningCentre.Database.LearningCentre.Data_Transfer_Objects;
using LearningCentre.Database.Tables;
using LearningCentre.Logics.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.IdentityModel.Tokens;
using IAuthenticationService = LearningCentre.Logics.Services.Interfaces.IAuthenticationService;

namespace LearningCentre.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [Authorize]
    [Route("[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userService"></param>
        public AuthenticationController(IAuthenticationService userService, IOptions<AppSettings> appSettings, IMapper mapper)
        {
            _userService = userService;
            _appSettings = appSettings.Value;
            _mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userParam"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] UserProfileTransfer userParam)
        {
            var user = _userService.Authenticate(userParam.Username, userParam.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);

            return Ok(new
            {
                Id = user.Id,
                Username = user.Username,
                Token = tokenString
            });
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] UserProfileTransfer userParam)
        {
            var user = _mapper.Map<UserProfile>(userParam);

            try
            {
                _userService.CreateUser(user, userParam.Password);
                return Ok();
            }
            catch (AppException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUsers")]
        public IActionResult GetUsers()
        {
            var users = _userService.GetUsers();
            var userTransfers = _mapper.Map<IList<UserProfileTransfer>>(users);
            return Ok(userTransfers);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Route("getUser")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUserById(id);
            var userTransfer = _mapper.Map<UserProfileTransfer>(user);
            return Ok(userTransfer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userParam"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Route("updateUser")]
        public IActionResult UpdateUser(int id, [FromBody] UserProfileTransfer userParam)
        {
            var user = _mapper.Map<UserProfile>(userParam);
            user.Id = id;

            try
            {
                _userService.UpdateUser(user, userParam.Password);
                return Ok();
            }
            catch (AppException ex)
            {
                return BadRequest(new {message = ex.Message});
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Route("deleteUser")]
        public IActionResult DeleteUser(int id)
        {
            _userService.Delete(id);
            return Ok();
        }
    }
}