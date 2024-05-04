using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Models;

namespace Nike_clone_Backend.Services.RoleService
{
    public interface IRoleService
    {
        Task<RoleModel?> GetRole(int id);
        Task<IEnumerable<RoleModel>> GetRoles();
        Task<RoleModel> AddRole(RoleModel role);
        Task UpdateRole(RoleModel role);
        Task DeleteRole(int id);

    }
}