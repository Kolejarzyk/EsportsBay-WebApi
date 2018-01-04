using EsportsBay.API.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EsportsBay.API.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        User Authenticate(string username, string password);
    }
}
