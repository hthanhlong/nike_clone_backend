using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Services.RoleService
{
    public interface IRoleService
    {
        Task<RoleModel> GetRole(int id);
        Task<IEnumerable<RoleModel>> GetRoles();
        Task<RoleModel> AddRole(RoleModel role);
        Task<RoleModel> UpdateRole(RoleModel role);
        Task<RoleModel> DeleteRole(int id);

    }
}