using Microsoft.EntityFrameworkCore;
using ministore.core.Entities;
using ministore.core.Repositories.Interfaces;
using ministore.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ministore.data.Repository.Implementations
{
    public class GenericReposaitory<TEntity> : IGenericRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly AppDbContext _context;

        public GenericReposaitory(AppDbContext context)
        {
           _context = context;
        }
        public DbSet<TEntity> Table => _context.Set<TEntity>();
        public async Task<int> CommitAsync()
        {
            return await  _context.SaveChangesAsync();
        }

        public Task CreateAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public IQueryable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> expression , params string[] includes)
        {
            var query = GetQuery(includes);
            return expression is not null
                 ? query.Where(expression)
                 : query;

        }

      
        public IQueryable<TEntity> GetAllAsync(params string[] includes)
        {
            var query = GetQuery(includes);
            return query;
        }
        public Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, params string[]? includes)
        {
            var query = GetQuery(includes);
            return expression is not null
                  ? query.Where(expression).FirstOrDefaultAsync()
                  : query.FirstOrDefaultAsync();
        }
        public  IQueryable<TEntity> GetQuery(params string[] includes)
        {
            var query = Table.AsQueryable();
            if(includes is not null && includes.Length>0)
            {
                foreach(var include in includes)
                {
                    query = query.Include(include);
                }

            }
            return query;


        }

       
    }
}
