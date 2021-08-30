using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;

namespace AccessControl.Services
{
    public interface IUserService
    {
        Task<User> Authenticate(string username, string password);
        // Task<IEnumerable<User>> GetAll();
    }
}