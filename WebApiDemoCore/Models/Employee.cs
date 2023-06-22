using System.ComponentModel.DataAnnotations;

namespace WebApiDemoCore.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;
        public int Salary { get; set; }
        [Required]
        public int DepartmentId { get; set; }
    }
}
