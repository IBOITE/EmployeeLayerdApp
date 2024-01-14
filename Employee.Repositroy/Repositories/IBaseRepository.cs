using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Repositroy.Repositories
{
    public interface IBaseRepository<T> where T : class
    {

        //T GetByID(int id);
        //IEnumerable<T> GetAll();
        //void updatee(T entity);



        Task<T> Insert(T entity);
        Task InsertRange(IEnumerable<T> list);
        Task<T> Update(T entity);
        Task Delete(int id);
        Task DeleteAll(IEnumerable<T> entitys);

        Task<T> Get(int id);
        IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> predicate, params string[] includes);
        Task<IEnumerable<T>> List();
        Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate);

        Task<int> Count();
        Task<int> Count(Expression<Func<T, bool>> predicate);
        Task<bool> Any(Expression<Func<T, bool>> predicate);
        
    }
}
