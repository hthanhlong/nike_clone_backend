using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Reformation.Dtos;
using Reformation.Dtos.AuthDtos;
using Reformation.Repositories.UserRepository;
using Reformation.Utils;

namespace Reformation.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public async Task SignUp(SignUpDto signUpDto)
        {
            var isUserExist = await _userRepository.GetUserByEmail(signUpDto.Email);
            if (isUserExist != null)
            {
                throw new Exception("User already exist");
            }
            var newUser = _mapper.Map<CreateUserDto>(signUpDto);
            await _userRepository.AddUser(newUser);
        }

        public async Task SignIn(SignInDto signInDto)
        {
            var isUserExist = await _userRepository.GetUserByEmail(signInDto.Email);
            if (isUserExist == null)
            {
                throw new Exception("User not found");
            }
            var hashedPassword = isUserExist.Password;
            var passwordHasher = new PasswordHasherUtils();
            var isPasswordCorrect = passwordHasher.VerifyPassword(hashedPassword, signInDto.Password);
            if (!isPasswordCorrect)
            {
                throw new Exception("Invalid password");
            }
        }

        public AuthService(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


    }
}

