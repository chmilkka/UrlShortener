namespace UrlShortener.Application.PasswordHasher
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

    }
}
