using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly ControlAccessContext _context;

        public RoleRepository(ControlAccessContext context)
        {
            _context = context;
        }

        public async Task<Role> Get(int id)
        {
            return await _context.Roles.FindAsync(id);
        }

        public async Task<IReadOnlyList<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }

        public async Task<Role> Create(Role entity)
        {
            _context.Roles.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(Role entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var roleToDelete = await _context.Roles.FindAsync(id);
            _context.Roles.Remove(roleToDelete);
            await _context.SaveChangesAsync();
        }
    }
}