using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using Microsoft.EntityFrameworkCore;

namespace AccessControl.Repository
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ControlAccessContext _context;

        public EmployeeRepository(ControlAccessContext context)
        {
            _context = context;
        }

        public async Task<Employee> Get(int id)
        {
            return await _context.Employees.FindAsync(id);
        }

        public async Task<IReadOnlyList<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }

        public async Task<Employee> Create(Employee entity)
        {
            _context.Employees.Add(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

        public async Task Update(Employee entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var employeeToDelete = await _context.Employees.FindAsync(id);
            _context.Employees.Remove(employeeToDelete);
            await _context.SaveChangesAsync();
        }
    }
}