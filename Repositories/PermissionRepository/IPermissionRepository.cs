using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.PermissionRepository
{
    public interface IPermissionRepository
    {
        Task<IEnumerable<PermissionModel>> GetPermissions();
        Task<PermissionModel> GetPermission(int id);
        Task<PermissionModel> AddPermission(PermissionModel permission);
        Task<PermissionModel> UpdatePermission(PermissionModel permission);
        Task<PermissionModel> DeletePermission(int id);

    }
}