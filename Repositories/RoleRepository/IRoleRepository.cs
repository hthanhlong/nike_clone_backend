using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;

namespace Reformation.Repositories.RoleRepository
{
    public interface IRoleRepository
    {
        Task<IEnumerable<RoleModel>> GetRoles();
        Task<RoleModel> GetRole(int id);
        Task<RoleModel> AddRole(RoleModel role);
        Task<RoleModel> UpdateRole(RoleModel role);
        Task<RoleModel> DeleteRole(int id);
    }
}