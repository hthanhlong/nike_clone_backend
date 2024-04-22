using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reformation.Dtos.AuthDtos;

namespace Reformation.Services.AuthService
{
    public interface IAuthService
    {
        public Task<bool> SignUp(SignUpDto signUpDto);
        public Task<bool> SignIn(SignInDto signInDto);

    }
}

