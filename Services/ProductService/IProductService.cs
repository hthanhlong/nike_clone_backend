using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services;
public interface IProductService
{
    Task<ProductModel> GetProduct(int id);
    Task<IEnumerable<ProductModel>> GetProducts
    (
        string sort,
        string search,
        int page,
        int limit
    );
    Task<ProductModel> AddProduct(ProductModel product);
    Task<ProductModel> UpdateProduct(ProductModel product);
    Task<ProductModel> DeleteProduct(int id);
}