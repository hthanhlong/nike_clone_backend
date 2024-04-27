using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.OrderRepository
{
    public class OrderRepository : IOrderRepository
    {
        public Task<OrderModel> AddOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> DeleteOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> GetOrder(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<OrderModel>> GetOrders()
        {
            throw new NotImplementedException();
        }

        public Task<OrderModel> UpdateOrder(OrderModel order)
        {
            throw new NotImplementedException();
        }
    }
}