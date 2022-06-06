using BE.Contracts;
using BE.Data.DbCtx;
using BE.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Services
{
    public class ProductService : IProdService
    {
        #region Readonly Fields

        private readonly ApplicationDbContext _dbContext;

        #endregion

        #region Ctor

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        #region Public Methods

        public async Task<List<Product>> GetProducts()
        {
            try
            {
                var results = await _dbContext.Products.ToListAsync();

                return AddPathPrefix(results);
            }
            catch (Exception)
            {
                throw;
            }
        }

        #endregion

        #region Private Methods

        private List<Product>AddPathPrefix(List<Product>products)
        {
            products.ForEach(x =>
            {
                x.Img = $"../assets/{x.Img}";
            });

            return products;
        }

        #endregion
    }
}
