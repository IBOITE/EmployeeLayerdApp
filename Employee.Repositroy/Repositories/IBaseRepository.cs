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

        

        T Insert(T entity);
        void InsertRange(IEnumerable<T> list);
        T Update(T entity);
        void Delete(int id);
        void DeleteAll(IEnumerable<T> entitys);

        T Get(int id);
        IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> predicate = null);
        IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> predicate, params string[] includes);
        IEnumerable<T> List();
        IEnumerable<T> List(int pagenumber,int pagesize);
        IEnumerable<T> List(Expression<Func<T, bool>> predicate);

        int Count();
        int Count(Expression<Func<T, bool>> predicate);
        bool Any(Expression<Func<T, bool>> predicate);




    }
}
