using TestWebAPI.Application.Services.Abstraction;

namespace TestWebAPI.Application.Services.Implementation
{
    public class HashPassword : IHashPassword
    {
        string IHashPassword.HashPassword(string password)
            => BCrypt.Net.BCrypt.EnhancedHashPassword(password);
        public bool VerifyPassword(string password, string HashPassword)
            => BCrypt.Net.BCrypt.EnhancedVerify(password, HashPassword);

    }
}
