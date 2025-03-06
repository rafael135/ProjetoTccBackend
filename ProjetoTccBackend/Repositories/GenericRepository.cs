using ProjetoTccBackend.Database;
using ProjetoTccBackend.Repositories.Interfaces;
using System.Linq.Expressions;

namespace ProjetoTccBackend.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly TccDbContext _dbContext;

        public GenericRepository(TccDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public virtual void Add(T entity)
        {
            this._dbContext.Set<T>().Add(entity);
            this._dbContext.SaveChanges();
        }

        public virtual void AddRange(IEnumerable<T> entities)
        {
            this._dbContext.Set<T>().AddRange(entities);
            this._dbContext.SaveChanges();
        }

        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            return this._dbContext.Set<T>().Where(expression);
        }

        public virtual IEnumerable<T> GetAll()
        {
            return this._dbContext.Set<T>().ToList();
        }

        public virtual T? GetById(int id)
        {
            return this._dbContext.Set<T>().Find(id);
        }

        public virtual void Remove(T entity)
        {
            this._dbContext.Set<T>().Remove(entity);
            this._dbContext.SaveChanges();
        }

        public virtual void RemoveRange(IEnumerable<T> entities)
        {
            
            this._dbContext.Set<T>().RemoveRange(entities);
            this._dbContext.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            this._dbContext.Set<T>().Update(entity);
            this._dbContext.SaveChanges();
        }

        public virtual void UpdateRange(IEnumerable<T> entities)
        {
            this._dbContext.Set<T>().UpdateRange(entities);
            this._dbContext.SaveChanges();
        }
    }
}
