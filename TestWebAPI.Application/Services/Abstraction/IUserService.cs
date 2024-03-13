using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;

namespace TestWebAPI.Application.Services.Abstraction
{
    internal interface IUserService
    {
        Task Register(User user, string Password);
    }
}
