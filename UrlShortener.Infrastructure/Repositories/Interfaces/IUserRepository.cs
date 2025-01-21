using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByLoginAsync(string login);
        Task CreateUser(User user);
    }
}
