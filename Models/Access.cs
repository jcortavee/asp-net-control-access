using System;

namespace AccessControl.Models
{
    public class Access
    {
        public int Id { get; set; }
        public Employee? Employee { get; set; }
        public int? EmployeeId { get; set; }
        public AccessType AccessType { get; set; }
        public int AccessTypeId { get; set; }
        public DateTime Date { get; set; }
    }
}