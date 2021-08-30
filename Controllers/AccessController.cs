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
    public class AccessessController : Controller
    {
        private readonly IAccessRepository _accessRepository;

        public AccessessController(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        // GET
        [HttpGet]
        public async Task<IReadOnlyList<Access>> GetAll()
        {
            return await _accessRepository.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Access>> GetAccess(int id)
        {
            return await _accessRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Access>> PostAccess([FromBody] Access access)
        {
            var newAccess = await _accessRepository.Create(access);
            return CreatedAtAction(nameof(GetAccess), new {id = newAccess.Id}, newAccess);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateAccess(int id, [FromBody] Access access)
        {
            if (id != access.Id)
            {
                return BadRequest();
            }

            await _accessRepository.Update(access);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var accessToDelete = await _accessRepository.Get(Id);

            if (accessToDelete == null)
            {
                return NotFound();
            }

            await _accessRepository.Delete(accessToDelete.Id);
            return NoContent();
        }
    }
}