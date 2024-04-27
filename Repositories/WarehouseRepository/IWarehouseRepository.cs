using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.WarehouseRepository
{
    public interface IWarehouseRepository
    {
        Task<IEnumerable<WarehouseModel>> GetWarehouses();
        Task<WarehouseModel> GetWarehouse(int id);
        Task<WarehouseModel> AddWarehouse(WarehouseModel warehouse);
        Task<WarehouseModel> UpdateWarehouse(WarehouseModel warehouse);
        Task<WarehouseModel> DeleteWarehouse(int id);
    }
}