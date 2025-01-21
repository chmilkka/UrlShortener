using System.Security.Cryptography;
using System.Text;

namespace UrlShortener.Application.PasswordHasher
{
    public class PasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            try
            {
                using (var sha256 = SHA256.Create())
                {
                    var passwordBytes = Encoding.UTF8.GetBytes(password);
                    var hashedBytes = sha256.ComputeHash(passwordBytes);
                    return Convert.ToBase64String(hashedBytes);
                }
            }
            catch (Exception) 
            {
                throw new NotImplementedException("Password hasher did not work");
            }    
        }
    }
}
