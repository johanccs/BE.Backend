using BE.Data.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BE.Contracts
{
    public interface IProdService
    {
        Task<List<Product>> GetProducts();
    }
}
