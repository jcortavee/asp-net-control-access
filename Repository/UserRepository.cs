using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ControlAccessContext _context;

        public UserRepository(ControlAccessContext context)
        {
            _context = context;
        }

        public async Task<User> Get(int id)
        {
            return await _context.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .Where(u => u.Id == id)
                .SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<User>> GetAll()
        {
            return await _context.Users
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .ToListAsync();
        }

        public async Task<User> Create(User entity)
        {
            _context.Users.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(User entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var userToDelete = await _context.Users.FindAsync(id);
            _context.Users.Remove(userToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByUsernameAndPassword(string username, string password)
        {
            return await _context.Users.Where(u => u.Username == username)
                .Include(u => u.Employee)
                .Include(u => u.Role)
                .Where(u => u.Password == password)
                .SingleOrDefaultAsync();
        }
    }
}