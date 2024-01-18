using Employee.Repositroy.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Employee.Data.RepositoryBase
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected ApplicationDbContext Context;
        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        /*
       
        public IEnumerable<T> GetAll()
        {
            return Context.Set<T>().ToList();
        }
        public T GetByID(int id)
        {
            return Context.Set<T>().Find(id);
        }
        
        public void updatee(T entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChangesAsync();
        }
        */
        



        public virtual  T Insert(T entity)
        {
            var result = ( Context.Set<T>().Add(entity)).Entity;
            Context.SaveChanges();
            //return await Get(result.Id);
            return result;
        }

        public virtual void InsertRange(IEnumerable<T> list)
        {
             Context.Set<T>().AddRange(list);
             Context.SaveChanges();
        }

        public virtual T Update(T entity)
        {
            /*
            var originalentity = await Get(entity.Id);
            if (originalentity == null) throw new Exception("Entity Not Found");

            entity.Id = originalentity.Id;
            Context.Entry(originalentity).CurrentValues.SetValues(entity);
            */
            Context.Entry(entity).State = EntityState.Modified;
            Context.SaveChanges();
            return entity;
        }

        

        public virtual void Delete(int id)
        {
            var entity = Get(id);
            if (entity == null) throw new Exception("IEntity Not Found");

            Context.Set<T>().Remove(entity);
            Context.SaveChanges();
        }

        public virtual void DeleteAll(IEnumerable<T> entitys)
        {
            Context.Set<T>().RemoveRange(entitys);
            Context.SaveChanges();
        }

        public virtual T Get(int id)
        {
            //var entity = await GetAsIQueryable(x => x.Id == id).FirstOrDefaultAsync();
            //return entity;
            return Context.Set<T>().Find(id);
        }

        public virtual IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> predicate = null)
        {
            IQueryable<T> query = Context.Set<T>();

            if (predicate != null)
                query = query.Where(predicate);

            return query;
        }

        public IQueryable<T> GetAsIQueryable(Expression<Func<T, bool>> predicate, params string[] includes)
        {
            IQueryable<T> query = Context.Set<T>();
            foreach (var include in includes)
            {
                query = query.Include(include);
            }

            query = query.Where(predicate);

            return query;
        }



        public virtual IEnumerable<T> List()
        {
            var entity =  Context.Set<T>()
                .ToList();

            return entity;
        }
        public virtual IEnumerable<T> List(int pagenumber,int pagesize)
        {
            var entity = Context.Set<T>().AsNoTracking().Skip(pagenumber*pagesize-pagesize).Take(pagesize)
                .ToList();

            return entity;
        }



        public virtual IEnumerable<T> List(Expression<Func<T, bool>> predicate)
        {
            var entity =  Context.Set<T>()
                .Where(predicate)
                .ToList();
            return entity;
        }

        public virtual int Count()
        {
            var count =  Context.Set<T>().Count();
            return count;
        }

        public virtual int Count(Expression<Func<T, bool>> predicate)
        {
            var count = Context.Set<T>().Count(predicate);
            return count;
        }

        public  bool Any(Expression<Func<T, bool>> predicate)
        {
            return Context.Set<T>().Any(predicate);
        }

        
    }
}
