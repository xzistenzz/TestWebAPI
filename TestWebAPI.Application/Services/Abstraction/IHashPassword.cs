using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWebAPI.Application.Services.Abstraction
{
    public interface IHashPassword
    {
        string HashPassword(string password);
        bool VerifyPassword(string password, string HashPassword);
    }
}
