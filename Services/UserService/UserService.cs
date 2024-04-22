using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Dtos;
using Reformation.Models;
using Reformation.Repositories.UserRepository;

namespace Reformation.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<List<UserModel>> GetUsers()
        {
            return await _userRepository.GetUsers();
        }

        public async Task<UserModel?> GetUser(int id)
        {
            return await _userRepository.GetUser(id);
        }

        public async Task AddUser(CreateUserDto user)
        {
            await _userRepository.AddUser(user);
        }
    }
}

