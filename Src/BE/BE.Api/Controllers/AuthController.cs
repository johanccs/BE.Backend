using BE.Common.ActionFilters;
using BE.Contracts;
using BE.Data.Dtos;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Private Readonly Field

        private readonly IAuthService _authService;

        #endregion

        #region Constructor

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        #endregion

        #region Methods

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> LoadAllUsers()
        {
            var result = await _authService.LoadAllUsers();

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            var result = await _authService.CreateUser(userDto);

            if (result == null)
                return BadRequest("User could not be created");
            else
                return Ok(result);
        }

        [HttpPut]
        [Route("edituser")]
        public async Task<ActionResult<EditUserDto>> EditUser(EditUserDto user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var result = await _authService.EditUser(user);

            if (result == null)
                return NotFound("User not found");
            else
                return Ok(result);
        }

        #endregion
    }
}
