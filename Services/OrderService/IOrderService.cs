using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Services.OrderService
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