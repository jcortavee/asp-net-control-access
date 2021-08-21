using System.ComponentModel.DataAnnotations;

namespace AccessControl.Models
{
    public class AccessType
    {
        [Key]
        public int Id { get; set; }
        public string Type { get; set; }
    }
}