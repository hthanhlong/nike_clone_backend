using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Services.RoleService;
using Nike_clone_Backend.UnitOfWork;

namespace Nike_clone_Backend.Services.PermissionService
{
    public class PermissionService : GenericService, IPermissionService
    {
        public PermissionService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        public async Task<PermissionModel> AddPermission(PermissionModel permission)
        {
            await _unitOfWork.PermissionRepository.Insert(permission);
            await _unitOfWork.SaveAsync();
            return permission;
        }

        public async Task DeletePermission(int id)
        {
            await _unitOfWork.PermissionRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public async Task<PermissionModel?> GetPermission(int id)
        {
            return await _unitOfWork.PermissionRepository.GetByIDAsync(id);
        }

        public async Task<IEnumerable<PermissionModel>> GetPermissions()
        {
            return await _unitOfWork.PermissionRepository.GetAllAsync();
        }

        public async Task UpdatePermission(PermissionModel permission)
        {
            _unitOfWork.PermissionRepository.Update(permission);
            await _unitOfWork.SaveAsync();
        }
    }
}