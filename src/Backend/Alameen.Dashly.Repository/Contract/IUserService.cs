using Dashly.API.Feature.UserManagement.Data.Entity;
using System.Collections.Generic;

namespace Dashly.API.Feature.UserManagement.Services
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}