
using AutoMapper;
using nike_clone_backend.Models.DTOs;
using nike_clone_backend.Shared.ErrorsExceptions;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Repositories;
namespace Nike_clone_Backend.Services
{
    public class UserService : GenericService, IUserService
    {
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork)
        {
            _mapper = mapper;
        }

        public async Task DeleteUser(int id)
        {
            await _unitOfWork.UserRepository.Delete(id);
            await _unitOfWork.SaveAsync();
        }

        public Task<UserModel?> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<UserModel>> GetUsers()
        {
            var users = await _unitOfWork.UserRepository.GetAllAsync();
            return _mapper.Map<List<UserModel>>(users);
        }

        public async Task UpdateUser(int id, UpdateUserDto updateUserDto)
        {
            var user = await _unitOfWork.UserRepository.GetByIDAsync(id);
            if (user == null)
            {
                throw new CustomException("User not found", 404);
            }
            _mapper.Map(updateUserDto, user);
            _unitOfWork.UserRepository.Update(user);
            await _unitOfWork.SaveAsync();
        }
    }
}

