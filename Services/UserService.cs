using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Models;
using Reformation.Repositories;

namespace Reformation.Services
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

        public async Task AddUser(UserModel user)
        {
            await _userRepository.AddUser(user);
        }
    }
}

