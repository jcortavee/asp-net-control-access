using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using AccessControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessTypesController : Controller
    {
        private readonly IAccessTypeRepository _accessTypeRepository;

        public AccessTypesController(IAccessTypeRepository accessTypeRepository)
        {
            _accessTypeRepository = accessTypeRepository;
        }

        // GET
        [HttpGet]
        public async Task<IReadOnlyList<AccessType>> GetAll()
        {
            return await _accessTypeRepository.GetAll();
        }
    }
}