using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccessControl.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public Employee Employee { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
}