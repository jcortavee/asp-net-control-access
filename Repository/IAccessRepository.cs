using System.Threading.Tasks;
using AccessControl.Models;

namespace AccessControl.Repository
{
    public interface IAccessRepository : IGenericRepository<Access>
    {
        Task<Access> GetLastInserted();
    }
}