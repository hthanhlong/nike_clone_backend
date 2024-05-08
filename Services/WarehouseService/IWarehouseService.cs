using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.WarehouseService
{
    public interface IWarehouseService
    {
        Task<WarehouseModel> GetWarehouse(int id);
        Task<IEnumerable<WarehouseModel>> GetWarehouses();
        Task<WarehouseModel> AddWarehouse(WarehouseModel warehouse);
        Task<WarehouseModel> UpdateWarehouse(WarehouseModel warehouse);
        Task<WarehouseModel> DeleteWarehouse(int id);
    }
}

