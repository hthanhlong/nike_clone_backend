
using AutoMapper;
using Nike_clone_Backend.Models;
using Nike_clone_Backend.Models.DTOs;
namespace Nike_clone_Backend;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<RefreshTokenDto, RefreshTokenModel>().ReverseMap();
        CreateMap<CreatePermissionDto, PermissionModel>().ReverseMap();
        CreateMap<CreateRoleDto, RoleModel>().ReverseMap();
        CreateMap<SignUpDto, UserModel>().ReverseMap();
        CreateMap<SignInDto, UserModel>().ReverseMap();
    }
}

