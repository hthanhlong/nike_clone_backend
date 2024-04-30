using Reformation.Classes;
using Reformation.Models;
using Reformation.UnitOfWork;
namespace Reformation.Services.UserService
{
    public class UserService : GenericService, IUserService
    {
        public UserService(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Task AddUser(ISignUp user)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel?> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<UserModel>> GetUsers()
        {
            throw new NotImplementedException();
        }
    }
}

