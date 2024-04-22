using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Dtos;
using Reformation.Models;

namespace Reformation.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this UserModel user)
        {
            return new UserDto
            {
                Name = user.Name,
                Email = user.Email,
            };
        }

    }
}