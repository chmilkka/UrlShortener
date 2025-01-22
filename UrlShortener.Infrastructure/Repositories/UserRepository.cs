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

            try
            {
                return await dbContext.Users.FirstOrDefaultAsync(u => u.Login == login);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("User with this Login was not found");
            }
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

        public async Task<User?> GetUserByIdAsync(Guid id)
        {
            if (string.IsNullOrWhiteSpace(id.ToString()))
            {
                throw new ArgumentException("ID cannot be null or empty.");
            }

            try
            {
                return await dbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
            }
            catch (Exception)
            {
                throw new KeyNotFoundException("User with this ID was not found");
            }          
        }
    }
}
