using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Repository
{
    public class AccessTypeRepository : IAccessTypeRepository
    {
        private readonly ControlAccessContext _context;

        public AccessTypeRepository(ControlAccessContext context)
        {
            _context = context;
        }

        public async Task<AccessType> Get(int id)
        {
            return await _context.AccessTypes.FindAsync(id);
        }

        public async Task<IReadOnlyList<AccessType>> GetAll()
        {
            return await _context.AccessTypes.ToListAsync();
        }

        public async Task<AccessType> Create(AccessType entity)
        {
            _context.AccessTypes.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(AccessType entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var accessTypeToDelete = await _context.AccessTypes.FindAsync(id);
            _context.AccessTypes.Remove(accessTypeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}