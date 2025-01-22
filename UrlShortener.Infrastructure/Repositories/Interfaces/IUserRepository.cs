using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User?> GetUserByLoginAsync(string login);
        Task<User?> GetUserByIdAsync(Guid id);
        Task CreateUser(User user);
    }
}
