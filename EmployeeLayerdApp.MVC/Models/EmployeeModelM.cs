using Employee.Repositroy.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeLayerdApp.MVC.Models
{
    public class EmployeeModelM
    {
        public int Id { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeSurName { get; set; }

        public int? EmployeeSalary { get; set; }
        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public virtual Department? Department { get; set; }

    }
}
