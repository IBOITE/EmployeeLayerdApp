﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositroy.Models
{
    public class Employe
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
