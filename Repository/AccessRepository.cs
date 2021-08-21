using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Repository
{
    public class AccessRepository : IAccessRepository
    {
        private readonly ControlAccessContext _context;

        public AccessRepository(ControlAccessContext context)
        {
            _context = context;
        }

        public async Task<Access> Get(int id)
        {
            return await _context.Accesses.FindAsync(id);
        }

        public async Task<IReadOnlyList<Access>> GetAll()
        {
            return await _context.Accesses.ToListAsync();
        }

        public async Task<Access> Create(Access entity)
        {
            _context.Accesses.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(Access entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var accessToDelete = await _context.Accesses.FindAsync(id);
            _context.Accesses.Remove(accessToDelete);
            await _context.SaveChangesAsync();
        }
    }
}