using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application.Models
{
    public class EmployeeModelS
    {
        public int Id { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeSurName { get; set; }

        public int? EmployeeSalary { get; set; }

        public int DepartmentId { get; set; }
    }
}
