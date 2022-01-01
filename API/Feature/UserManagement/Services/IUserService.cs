using System.Collections.Generic;
using Dashly.API.Repositories.Data.Entity;

namespace Dashly.API.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}