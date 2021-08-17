using System.Collections;
using System.Collections.Generic;

namespace AccessControl.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string EmployeeCode { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public User User { get; set; }
        public ICollection<Access> Accesses { get; set; }
    }
}