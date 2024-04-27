using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.WarehouseRepository
{
    public class WarehouseRepository : IWarehouseRepository
    {
        public Task<WarehouseModel> AddWarehouse(WarehouseModel warehouse)
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseModel> DeleteWarehouse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseModel> GetWarehouse(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<WarehouseModel>> GetWarehouses()
        {
            throw new NotImplementedException();
        }

        public Task<WarehouseModel> UpdateWarehouse(WarehouseModel warehouse)
        {
            throw new NotImplementedException();
        }
    }
}