using Employee.Application.Pagination;
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
    public class Service : IService
    {
        private readonly IBaseRepository<Department> _departmentRepository;
        private readonly IBaseRepository<Employe> _employeeRepository;

        public Service(IBaseRepository<Department> departmentRepository, IBaseRepository<Employe> employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _departmentRepository = departmentRepository;
        }

        public IEnumerable<Department> GetAllDepartments()
        {
            return _departmentRepository.List();
        }
        public IEnumerable<Department> GetAllDepartments(int pagenumber, int pagesize)
        {
            return _departmentRepository.List(pagenumber,pagesize);
        }

        public IEnumerable<Employe> GetAllEmployees()
        {
            return _employeeRepository.List();
        }
        public IEnumerable<Employe> GetAllEmployees(int pagenumber, int pagesize)
        {
            return _employeeRepository.List(pagenumber, pagesize);
        }

        public Department GetDepartment(int id)
        {
            return  _departmentRepository.Get(id);
        }

        public  Employe GetEmployee(int id)
        {
            return  _employeeRepository.Get(id);
        }

        public void PostDepartment(Department department)
        {
            _departmentRepository.Insert(department);
        }

        public void PostEmployee(Employe employe)
        {
            _employeeRepository.Insert(employe);
        }

        public  Department PutDepartment(Department department)
        {
            _departmentRepository.Update(department);
            return department;
        }

        public Employe PutEmployee(Employe employe)
        {
            _employeeRepository.Update(employe);
            return employe;
        }

        public void DeleteDepartment(int id)
        {
            _departmentRepository.Delete(id);
        }

        public void DeleteEmployee(int id)
        {
             _employeeRepository.Delete(id);
        }
        public int CountDepartements()
        {
            return _departmentRepository.Count();
        }
        public int CountEmployees()
        {
            return _employeeRepository.Count();
        }
        public bool AnyDepartment(Expression<Func<Department, bool>> predicate)
        {
            return _departmentRepository.Any(predicate);
        }
        public bool AnyEmployee(Expression<Func<Employe, bool>> predicate)
        {
            return _employeeRepository.Any(predicate);
        }


        
        public Task<PagedList<Employe>> GetAllEmployeesPa(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Employe>.
                GetPagedList(_employeeRepository.GetAll().OrderBy(s => s.Id),
                pagingParameters.PageNum, pagingParameters.PageSize));
        }

        
    }
}