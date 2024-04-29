using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Services.ProductService
{
    public interface IProductService
    {
        Task<ProductModel> GetProduct(int id);
        Task<IEnumerable<ProductModel>> GetProducts();
        Task<ProductModel> AddProduct(ProductModel product);
        Task<ProductModel> UpdateProduct(ProductModel product);
        Task<ProductModel> DeleteProduct(int id);
    }
}