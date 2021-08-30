using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using AccessControl.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        // GET
        [HttpGet]
        public async Task<IReadOnlyList<Employee>> GetAll()
        {
            return await _employeeRepository.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            return await _employeeRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> PostTeams([FromBody] Employee employee)
        {
            var newEmployee = await _employeeRepository.Create(employee);
            return CreatedAtAction(nameof(GetEmployee), new {id = newEmployee.Id}, newEmployee);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateTeams(int id, [FromBody] Employee employee)
        {
            if (id != employee.Id)
            {
                return BadRequest();
            }

            await _employeeRepository.Update(employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var employeeToDelete = await _employeeRepository.Get(Id);

            if (employeeToDelete == null)
            {
                return NotFound();
            }

            await _employeeRepository.Delete(employeeToDelete.Id);
            return NoContent();
        }
    }
}