using SharpForum.API.Models.Domain;

namespace SharpForum.API.Services.Security
{
    public interface ITokenService
    {
        public string CreateToken(User user, DateTime expiration);
    }
}