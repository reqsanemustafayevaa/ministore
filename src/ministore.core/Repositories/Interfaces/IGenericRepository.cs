using Microsoft.EntityFrameworkCore;
using ministore.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace ministore.core.Repositories.Interfaces
{
    public interface IGenericRepository<TEntity>where TEntity : BaseEntity, new()
    {
        DbSet<TEntity> Table { get; }
        Task CreateAsync(TEntity entity);
       
        IQueryable<TEntity> GetAllWhere(Expression<Func<TEntity, bool>> expression , params string[] includes);
        Task<TEntity> GetSingleAsync(Expression<Func<TEntity, bool>> expression, params string[] includes);
        IQueryable<TEntity> GetAllAsync(params string[] includes);
        void Delete(TEntity entity);
        Task<int> CommitAsync();
       
    }
}
