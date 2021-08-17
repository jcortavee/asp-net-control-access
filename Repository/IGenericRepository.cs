using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;

namespace AccessControl.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        Task<T> Get(int id);
        Task<IReadOnlyList<T>> GetAll();
        Task<T> Create(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}