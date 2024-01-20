namespace EmployeeLayerdApp.api.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public string? EmployeeName { get; set; }

        public string? EmployeeSurName { get; set; }

        public int? EmployeeSalary { get; set; }

        public int DepartmentId { get; set; }
    }
}
