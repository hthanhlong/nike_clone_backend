using AutoMapper;
using Reformation.Dtos;
using Reformation.Dtos.AuthDtos;
using Reformation.Models;

namespace Reformation.Mappers.AuthMappers
{
    public class AuthMappers : Profile
    {
        public AuthMappers()
        {
            CreateMap<SignUpDto, CreateUserDto>().ReverseMap();
        }
    }
}