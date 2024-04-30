using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Services.RoleService
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