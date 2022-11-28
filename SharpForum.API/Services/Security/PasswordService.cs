using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace SharpForum.API.Services.Security
{
    public class PasswordService : IPasswordService
    {
        private readonly IConfiguration _config;

        public PasswordService(IConfiguration config)
        {
            _config = config;
        }

        public string GetPasswordHash(string password)
        {
            byte[] salt = Encoding.ASCII.GetBytes(_config["Salt"]);
            byte[] hash = KeyDerivation.Pbkdf2(password, salt, KeyDerivationPrf.HMACSHA256, 8, 8);
            return Convert.ToBase64String(hash);
        }

        public bool CheckPassword(string password, string hashedPassword)
        {
            return String.Equals(GetPasswordHash(password), hashedPassword);
        }
    }
}