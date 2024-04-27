using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.OrderRepository
{
    public interface IOrderRepository
    {
        Task<IEnumerable<OrderModel>> GetOrders();
        Task<OrderModel> GetOrder(int id);
        Task<OrderModel> AddOrder(OrderModel order);
        Task<OrderModel> UpdateOrder(OrderModel order);
        Task<OrderModel> DeleteOrder(int id);

    }
}