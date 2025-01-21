namespace UrlShortener.Domain.Entities
{
    public class User
    {
        public Guid Id { get; set; } 
        public string Login { get; set; } 
        public string PasswordHash { get; set; } 
        public string Role { get; set; }
        public IEnumerable<ShortUrl> ShortUrls { get; set; }
    }
}
