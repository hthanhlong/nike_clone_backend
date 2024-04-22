using AutoMapper;
using Reformation.Dtos;
using Reformation.Models;
namespace Reformation.Mappers.UserMappers
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<UserModel, GetUserDto>().ReverseMap();
            CreateMap<UserModel, CreateUserDto>().ReverseMap();
        }
    }
}