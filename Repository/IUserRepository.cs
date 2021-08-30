using System.Threading.Tasks;
using AccessControl.Models;

namespace AccessControl.Repository
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> GetUserByUsernameAndPassword(string Username, string Password);
    }
}