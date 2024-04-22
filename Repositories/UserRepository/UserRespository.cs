using Reformation.Database;
using Reformation.Models;
using Microsoft.EntityFrameworkCore;
using Reformation.Dtos;
using AutoMapper;
using Reformation.Utils;

namespace Reformation.Repositories.UserRepository
{
    public class UserRepository : IUserRepository
    {

        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserRepository(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<UserModel>> GetUsers()
        {
            return await _context.UserModel.ToListAsync();
        }

        public async Task<UserModel?> GetUser(int id)
        {
            return await _context.UserModel.FindAsync(id);
        }

        public async Task<UserModel?> GetUserByEmail(string email)
        {
            return await _context.UserModel.FirstOrDefaultAsync(user => user.Email == email);
        }

        public async Task AddUser(CreateUserDto user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }
            else
            {
                var newUser = _mapper.Map<UserModel>(user);
                var passwordHasher = new PasswordHasherUtils();
                newUser.Password = passwordHasher.HashPassword(newUser.Password);
                await _context.UserModel.AddAsync(newUser);
                await _context.SaveChangesAsync();
            }

            if (!_context.SaveChangesAsync().IsCompletedSuccessfully)
            {
                throw new Exception("User not created");
            }
        }

    }
}

