using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Entities;
using BE.Services;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BE.Tests.Services
{
    public class ProductServiceTests
    {
        ApplicationDbContext _dbContext;
        IProdService _prodService;

        public ProductServiceTests()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase("MockBETS")
                .Options;

            _dbContext = new ApplicationDbContext(options);
            _prodService = new ProductService(_dbContext);

          
        }

        [Fact]
        public async Task Should_Retrieve_List_Of_Products()
        {
            PopulateWithTestDetail();

            var prods = await _prodService.GetProducts();

            Assert.True(prods != null);
            Assert.True(prods.Count > 0);
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
