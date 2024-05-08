using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.OrderService
{
    public interface IOrderService
    {
        Task<OrderModel> GetOrder(int id);
        Task<IEnumerable<OrderModel>> GetOrders();
        Task<OrderModel> AddOrder(OrderModel order);
        Task<OrderModel> UpdateOrder(OrderModel order);
        Task<OrderModel> DeleteOrder(int id);
    }
}