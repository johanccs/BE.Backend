using AutoMapper;
using BE.Common.ActionFilters;
using BE.Contracts;
using BE.Data.Dtos;
using BE.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BE.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        #region Private Readonly Field

        private readonly IAuthService _authService;
        private readonly IMapper _mapper;
        private readonly IPasswordHelper _passwordHelper;

        #endregion

        #region Constructor

        public AuthController(
            IAuthService authService, IMapper mapper, IPasswordHelper passwordHelper)
        {
            _authService = authService;
            _mapper = mapper;
            _passwordHelper = passwordHelper;
        }

        #endregion

        #region Methods

        [HttpGet ("{id}", Name ="getUser")]
        public async Task<ActionResult<ListUserDto>> Get(int id)
        {
            var result = await _authService.GetUser(id);

            if (result == null)
                return NotFound();
            else
                return Ok(result);
        }

        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<ActionResult<UserDto>> CreateUser(UserDto userDto)
        {
            var hashedPassword = _passwordHelper.HashPassword(userDto.Password);

            var user = _mapper.Map<User>(userDto);
            user.HashedPassword = hashedPassword;

            var result = await _authService.CreateUser(user);

            if (result == null)
                return BadRequest("User could not be created");
            else
            {
                var listUserDto =_mapper.Map<ListUserDto>(result);

                return new CreatedAtRouteResult("getUser", new { Id = listUserDto.Id }, listUserDto);
            }
        }

        #endregion
    }
}
