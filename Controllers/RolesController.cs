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
    public class RolesController : Controller
    {
        private readonly IRoleRepository _roleRepository;

        public RolesController(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        // GET
        [HttpGet]
        public async Task<IReadOnlyList<Role>> GetAll()
        {
            return await _roleRepository.GetAll();
        }
    }
}