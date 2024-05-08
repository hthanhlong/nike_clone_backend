using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.RoleService
{
    public interface IPermissionService
    {
        Task<PermissionModel?> GetPermission(int id);
        Task<IEnumerable<PermissionModel>> GetPermissions();
        Task<PermissionModel> AddPermission(PermissionModel permission);
        Task UpdatePermission(PermissionModel permission);
        Task DeletePermission(int id);

    }
}