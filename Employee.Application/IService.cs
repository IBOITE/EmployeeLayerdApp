using Employee.Application.Pagination;
using Employee.Repositroy.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Application
{
    public interface IService
    {
        IEnumerable<Department> GetAllDepartments();
        IEnumerable<Department> GetAllDepartments(int pagenumber,int pagesize);
        IEnumerable<Employe> GetAllEmployees();
        IEnumerable<Employe> GetAllEmployees(int pagenumber, int pagesize);
        Department GetDepartment(int id);
        Employe GetEmployee(int id);
        void PostDepartment(Department department);
        void PostEmployee(Employe employe);
        Department PutDepartment(Department department);
        Employe PutEmployee(Employe employe);
        void DeleteDepartment(int id);
        void DeleteEmployee(int id);
        int CountDepartements();
        int CountEmployees();
        bool AnyDepartment(Expression<Func<Department, bool>> predicate);
        bool AnyEmployee(Expression<Func<Employe, bool>> predicate);

        
        Task<PagedList<Employe>>GetAllEmployeesPa(PagingParameters pagingParameters);

    }
}
