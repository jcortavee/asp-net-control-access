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
        private readonly IAccessRepository _accessRepository;

        public UserService(IUserRepository userRepository, IAccessRepository accessRepository)
        {
            _userRepository = userRepository;
            _accessRepository = accessRepository;
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
            
            var access = await _accessRepository.GetLastInserted();
            if (access == null)
            {
                await _accessRepository.Create(new Access()
                {
                    EmployeeId = user.Employee.Id,
                    AccessTypeId = 1,
                    Date = DateTime.Now
                });
            }
            else
            {
                if (access.AccessTypeId == 1)
                {
                    await _accessRepository.Create(new Access()
                    {
                        EmployeeId = user.Employee.Id,
                        AccessTypeId = 2,
                        Date = DateTime.Now
                    });
                }
                else
                {
                    await _accessRepository.Create(new Access()
                    {
                        EmployeeId = user.Employee.Id,
                        AccessTypeId = 1,
                        Date = DateTime.Now
                    });
                }
            }

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