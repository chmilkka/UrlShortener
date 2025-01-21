using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Interfaces
{
    public interface IUserService
    {
        Task RegisterUserAsync(string login, string password);
        Task<User> AuthenticateUserAsync(string login, string password);
    }
}
