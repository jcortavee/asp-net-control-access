using System.Collections.Generic;
using System.Threading.Tasks;
using AccessControl.Models;
using AccessControl.Repository;
using AccessControl.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AccessControl.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : Controller
    {

        private readonly IUserService _userService;
        private readonly IUserRepository _userRepository;

        public UsersController(IUserService userService, IUserRepository userRepository)
        {
            _userService = userService;
            _userRepository = userRepository;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate([FromBody]AuthenticateModel model)
        {
            var user = await _userService.Authenticate(model.Username, model.Password);

            if (user == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(user);
        }
        
        
        [HttpGet]
        public async Task<IReadOnlyList<User>> GetAll()
        {
            return await _userRepository.GetAll();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            return await _userRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostTeams([FromBody] User user)
        {
            var newUser = await _userRepository.Create(user);
            return CreatedAtAction(nameof(GetUser), new {id = newUser.Id}, newUser);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateUser(int id, [FromBody] User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            await _userRepository.Update(user);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var userToDelete = await _userRepository.Get(Id);

            if (userToDelete == null)
            {
                return NotFound();
            }

            await _userRepository.Delete(userToDelete.Id);
            return NoContent();
        }
    }
}