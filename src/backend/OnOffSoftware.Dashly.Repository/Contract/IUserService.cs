using OnOffSoftware.Dashly.Core;
using System.Collections.Generic;

namespace OnOffSoftware.Dashly.Repository.Contract
{
    public interface IUserService
    {
        User Authenticate(string username, string password);

        IEnumerable<User> GetAll();

        User GetById(int id);
    }
}