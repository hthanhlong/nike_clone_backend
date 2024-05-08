using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.ProductService
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