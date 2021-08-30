using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace AccessControl.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public User User { get; set; }
        [JsonIgnore]
        public int UserId { get; set; }
        public ICollection<Access>? Accesses { get; set; }
    }
}