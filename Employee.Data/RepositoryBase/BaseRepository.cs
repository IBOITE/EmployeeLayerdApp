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



        public virtual async Task<T> Insert(T entity)
        {
            var result = (await Context.Set<T>().AddAsync(entity)).Entity;
            await Context.SaveChangesAsync();
            //return await Get(result.Id);
            return result;
        }

        public virtual async Task InsertRange(IEnumerable<T> list)
        {
            await Context.Set<T>().AddRangeAsync(list);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<T> Update(T entity)
        {
            /*
            var originalentity = await Get(entity.Id);
            if (originalentity == null) throw new Exception("Entity Not Found");

            entity.Id = originalentity.Id;
            Context.Entry(originalentity).CurrentValues.SetValues(entity);
            */
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }

        

        public virtual async Task Delete(int id)
        {
            var entity = await Get(id);
            if (entity == null) throw new Exception("IEntity Not Found");

            Context.Set<T>().Remove(entity);
            await Context.SaveChangesAsync();
        }

        public virtual async Task DeleteAll(IEnumerable<T> entitys)
        {
            Context.Set<T>().RemoveRange(entitys);
            await Context.SaveChangesAsync();
        }

        public virtual async Task<T> Get(int id)
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



        public virtual async Task<IEnumerable<T>> List()
        {
            var entity = await Context.Set<T>()
                .ToListAsync();

            return entity;
        }
        


        public virtual async Task<IEnumerable<T>> List(Expression<Func<T, bool>> predicate)
        {
            var entity = await Context.Set<T>()
                .Where(predicate)
                .ToListAsync();
            return entity;
        }

        public virtual async Task<int> Count()
        {
            var count = await Context.Set<T>().CountAsync();
            return count;
        }

        public virtual async Task<int> Count(Expression<Func<T, bool>> predicate)
        {
            var count = await Context.Set<T>().CountAsync(predicate);
            return count;
        }

        public async Task<bool> Any(Expression<Func<T, bool>> predicate)
        {
            return await Context.Set<T>().AnyAsync(predicate);
        }

        
    }
}
