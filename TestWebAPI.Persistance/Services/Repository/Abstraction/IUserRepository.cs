using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebAPI.Domain.Models;

namespace TestWebAPI.Persistance.Services.Repository.Abstraction
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetbyLogin(string login);
    }
}
