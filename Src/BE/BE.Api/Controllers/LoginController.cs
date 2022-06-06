using AutoMapper;
using BE.Common.Config;
using BE.Contracts;
using BE.Data.Dtos;
using BE.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BE.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Readonly Fields

        private readonly ILoginService _loginService;
        private readonly ILoggerService _logger;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;

        #endregion

        #region Ctor

        public LoginController(
            ILoginService loginService, 
            IMapper mapper, 
            IPasswordHelper passwordHelper,
            ILoggerService logger)
        {
            _loginService = loginService;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
            _logger = logger;
        }

        #endregion

        #region Methods

        [HttpPost()]
        public async Task<IActionResult> Get([FromBody] LoginDto login)
        {
            try
            {
                if (!ModelState.IsValid || login == null)
                    return BadRequest();

                var user = _mapper.Map<User>(login);
                user.HashedPassword = _passwordHelper.HashPassword(login.Password);

                var result = await _loginService.Login(user);

                if (result == null)
                    return Unauthorized("Invalid username or password");

                var mappedUser = _mapper.Map<LoggedInDto>(result);
                var tokenString = GlobalConfig.GenerateJWTToken();

                _logger.LoginIngo($"User logged in @ {DateTime.Now.ToString("dd-MM-yyyy")}");

                return Ok(new { 
                    Token = tokenString, 
                    UserId = mappedUser.Id, 
                    Name = mappedUser.Name, 
                    Surname = mappedUser.Surname });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
