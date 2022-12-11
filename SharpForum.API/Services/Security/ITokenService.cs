using SharpForum.API.Models.Domain;
using System.Collections.Generic;

namespace SharpForum.API.Services.Security
{
    public interface ITokenService
    {
        public string CreateToken(User user, DateTime expiration);

        public Dictionary<string, string> DecodeToken(string token);
    }
}