
using EventManager.Data;
using Microsoft.EntityFrameworkCore;

namespace EventManager.Models.DataLayer
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected AppDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(AppDbContext ctx)
        {
            _context = ctx;
            _dbSet = ctx.Set<T>();
        }

        public virtual void Add(T entity)
        {
            _dbSet.Add(entity);
        }

        public virtual void Delete(T entity)
        {
            _dbSet.Remove(entity);
        }

        public virtual IEnumerable<T> List(QueryOptions<T> options)
        {
            IQueryable<T> query = _dbSet;
            foreach (string include in options.GetIncludes())
            {
                query = query.Include(include);
            }

            if(options.HasWhere)
                query = query.Where(options.Where);
            if (options.HasOrderBy)
                query = query.OrderBy(options.OrderBy);
            if(options.HasPaging)
                query = query.PageBy(options.PageNumber, options.PageSize);

            return query;
        }

        public virtual void Save()
        {
            _context.SaveChanges();
        }

        public virtual void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
