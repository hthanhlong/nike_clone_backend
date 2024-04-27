using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.ProductRepository
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> GetProduct(int id);
        Task<ProductModel> AddProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<ProductModel> DeleteProduct(int id);
    }
}