using Employee.Repositroy.Models;
using Employee.Repositroy.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application
{
    internal class Service : IService
    {
        //private readonly IBaseRepository<Department> _departmentRepository;
        //private readonly IBaseRepository<Employe> _employeeRepository;

        //public Service(IBaseRepository<Department> departmentRepository, IBaseRepository<Employe> employeeRepository)
        //{
        //    _employeeRepository = employeeRepository;
        //    _departmentRepository = departmentRepository;
        //}

        //public Task<IEnumerable<Department>> GetAllDepartments()
        //{
        //    return _departmentRepository.List();
        //}

        //public Task<IEnumerable<Employe>> GetAllEmployees()
        //{
        //    return _employeeRepository.List();
        //}

        //public async Task<Department> GetDepartment(int id)
        //{
        //    return await _departmentRepository.Get(id);
        //}

        //public async Task<Employe> GetEmployee(int id)
        //{
        //    return await _employeeRepository.Get(id);
        //}

        //public void PostDepartment(Department department)
        //{
        //    _departmentRepository.Insert(department);
        //}

        //public void PostEmployee(Employe employe)
        //{
        //    _employeeRepository.Insert(employe);
        //}

        //public async Task<Department> PutDepartment(Department department)
        //{
        //    _departmentRepository.Update(department);
        //    return department;
        //}

        //public async Task<Employe> PutEmployee(Employe employe)
        //{
        //    _employeeRepository.Update(employe);
        //    return employe;
        //}

        //public async Task DeleteDepartment(int id)
        //{
        //    await _departmentRepository.Delete(id);
        //}

        //public async Task DeleteEmployee(int id)
        //{
        //    await _employeeRepository.Delete(id);
        //}
    }
}
