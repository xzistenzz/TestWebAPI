using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Application.Services.Abstraction;
using TestWebAPI.Domain.Models;
using TestWebAPI.Persistance.Services.Repository.Abstraction;

namespace TestWebAPI.Application.Services.Implementation
{
    internal class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPassword _hashPassword;

        public UserService(IUserRepository userRepository, IHashPassword hashPassword)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
        }

        public async Task Register(User user, string password)
        {
            user.HashPassword = _hashPassword.HashPassword(password);

            await _userRepository.CreateAsync(user);
        }
    }
}
