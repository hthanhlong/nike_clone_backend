using AutoMapper;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Repositories;

namespace Nike_clone_Backend.Services;
public class RoleService : GenericService, IRoleService
{
    private readonly IMapper _mapper;
    public RoleService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
    {
        _mapper = mapper;
    }

    public async Task<RoleModel> AddRole(RoleModel role)
    {
        await _unitOfWork.RoleRepository.Insert(role);
        await _unitOfWork.SaveAsync();
        return role;

    }

    public async Task DeleteRole(int id)
    {
        await _unitOfWork.RoleRepository.Delete(id);
        await _unitOfWork.SaveAsync();
    }

    public async Task<RoleModel?> GetRole(int id)
    {
        return await _unitOfWork.RoleRepository.GetByIDAsync(id);
    }

    public async Task<IEnumerable<RoleModel>> GetRoles()
    {
        return await _unitOfWork.RoleRepository.GetAllAsync();
    }

    public async Task UpdateRole(RoleModel role)
    {
        _unitOfWork.RoleRepository.Update(role);
        await _unitOfWork.SaveAsync();
    }
}