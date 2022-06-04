using BE.Api.AutoMapperProfile;
using BE.Common.Config;
using BE.Contracts;
using BE.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        #region Readonly Fields

        private readonly ILoginService _loginService;


        #endregion

        #region Ctor

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
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

                var loggedUser = await _loginService.Login(login);

                if (loggedUser == null)
                    return Unauthorized();

                var tokenString = GlobalConfig.GenerateJWTToken();

                return Ok(new { Token = tokenString, Name = loggedUser.Name, Surname = loggedUser.Surname });

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion
    }
}
