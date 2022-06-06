using AutoMapper;
using BE.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BE.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        #region Readonly Fields

        private readonly IProdService _prodService;
        private readonly IMapper _mapper;

        #endregion

        #region Ctor

        public ProductsController(IProdService prodService, IMapper mapper)
        {
            _prodService = prodService;
            _mapper = mapper;
        }

        #endregion

        #region Methods

        [HttpGet()]
        [ResponseCache(Duration = 120)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _prodService.GetProducts();

                if (result == null)
                    return NotFound();

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
