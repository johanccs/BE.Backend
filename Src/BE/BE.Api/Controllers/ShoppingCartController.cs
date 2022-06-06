using AutoMapper;
using BE.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using BE.Data.Entities;
using System.Collections.Generic;

namespace BE.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        #region Readonly Fields

        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public ShoppingCartController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpPost()]
        public async Task<IActionResult> CreateCartItem(List<CartItem> cartItems)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest("Invalid parameter");
                }

                var result = await _cartService.CheckOut(cartItems);

                if (!result)
                    return BadRequest("Cart not updated");

                //var mappedProducts = _mapper.Map<ListProductDto>(result);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #endregion

    }
}
