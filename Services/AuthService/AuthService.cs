using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reformation.Dtos;
using Reformation.Dtos.AuthDtos;
using Reformation.Repositories.UserRepository;

namespace Reformation.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public async Task<bool> SignIn(SignInDto signInDto)
        {
            var isUserExist = await _userRepository.GetUserByEmail(signInDto.Email);
            if (isUserExist == null)
            {
                throw new Exception("User not found");
            }
            var password = isUserExist.Password;
            if (password != signInDto.Password)
            {
                throw new Exception("Invalid password");
            }
            return true;
        }

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<bool> SignUp(SignUpDto signUpDto)
        {
            if (signUpDto == null)
            {
                throw new ArgumentNullException(nameof(signUpDto));
            }
            var isUserExist = await _userRepository.GetUserByEmail(signUpDto.Email);
            if (isUserExist != null)
            {
                throw new Exception("User already exist");
            }
            var newUser = _mapper.Map<CreateUserDto>(signUpDto);
            await _userRepository.AddUser(newUser);
            return true;
        }
    }
}

