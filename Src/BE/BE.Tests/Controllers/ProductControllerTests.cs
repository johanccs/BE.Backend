using AutoMapper;
using BE.Api.Controllers;
using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Entities;
using BE.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BE.Tests.Controllers
{
    public class ProductControllerTests
    {
        ApplicationDbContext _dbContext;
        ProductsController _controller;
        IProdService _prodService;
        IMapper _mapper;

        public ProductControllerTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("MockBETS")
               .Options;

            _dbContext = new ApplicationDbContext(options);

            _prodService = new ProductService(_dbContext);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Product, Product>();
            });

            _mapper = config.CreateMapper();

            _controller = new ProductsController(_prodService, _mapper);
        }

        [Fact]
        public async  Task Should_Get_List_Of_Products()
        {
            PopulateWithTestDetail();
            var result = await _controller.Get();

            Assert.True(result != null);
            Assert.True(((List<Product>)((ObjectResult)result).Value).Count > 0);
        }

        private void PopulateWithTestDetail()
        {
            for (int i = 0; i <= 10; i++)
            {
                var prod = new Product();
                prod.Img = $"img{i}";
                prod.Name = $"Product{i}";
                prod.Price = 23 * i;
                prod.Qty = 100 + 1;

                _dbContext.Add(prod);
                _dbContext.SaveChanges();
            }
        }
    }
}
