using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Entities;
using UrlShortener.Infrastructure.Repositories.Interfaces;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UserRepository(ApplicationDbContext dbContext) : IUserRepository
    {
        public async Task<User?> GetUserByLoginAsync(string login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                throw new ArgumentException("Login cannot be null or empty.", nameof(login));
            }

            return await dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
        }
        public async Task CreateUser(User user)
        {
            try
            {
               await dbContext.AddAsync(user);
               await dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new DbUpdateException("An error occurred while saving the user.");
            }
        }
    }
}
