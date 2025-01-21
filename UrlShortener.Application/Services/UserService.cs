using UrlShortener.Application.Interfaces;
using UrlShortener.Application.PasswordHasher;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Enums;
using UrlShortener.Domain.Exceptions;
using UrlShortener.Infrastructure.Repositories.Interfaces;

namespace UrlShortener.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public UserService(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public User AuthenticateUserAsync(string login, string password)
        {
            throw new NotImplementedException();
        }

        public async Task RegisterUserAsync(string login, string password)
        {
            var existingUser = await _userRepository.GetUserByLoginAsync(login);

            if (existingUser != null)
            {
                throw new ExistingUserException();
            }

            var user = new User
            {
                Id = Guid.NewGuid(),
                Login = login,
                PasswordHash = _passwordHasher.HashPassword(password),
                Role = Role.User.ToString()
            };

            await _userRepository.CreateUser(user);
        }
    }
}
