using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using AccessControl.Repository;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccessesController : Controller
    {
        private readonly IAccessRepository _accessRepository;

        public AccessesController(IAccessRepository accessRepository)
        {
            _accessRepository = accessRepository;
        }

        // GET
        [HttpGet]
        public async Task<IReadOnlyList<Access>> GetAll()
        {
            return await _accessRepository.GetAll();
        }
    }
}