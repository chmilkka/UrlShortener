using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
