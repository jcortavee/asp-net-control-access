using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AccessControl.Models;
using AccessControl.Repository;

namespace AccessControl.Services
{
    public class UserService : IUserService
    {
        
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // users hardcoded for simplicity, store in a db with hashed passwords in production applications
        // private List<User> _users = new List<User>
        // {
        //     new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
        // };

        public async Task<User> Authenticate(string username, string password)
        {
            // wrapped in "await Task.Run" to mimic fetching user from a db
            var user = await _userRepository.GetUserByUsernameAndPassword(username, password);

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so return user details
            return user;
        }

        public Task<IEnumerable<User>> GetAll()
        {
            throw new System.NotImplementedException();
        }

        // public async Task<IEnumerable<User>> GetAll()
        // {
        //     // wrapped in "await Task.Run" to mimic fetching users from a db
        //     return await Task.Run(() => _users);
        // }
    }
}