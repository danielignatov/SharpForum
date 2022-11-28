namespace SharpForum.API.Services.Security
{
    public interface IPasswordService
    {
        public string GetPasswordHash(string password);

        public bool CheckPassword(string password, string hashedPassword);
    }
}