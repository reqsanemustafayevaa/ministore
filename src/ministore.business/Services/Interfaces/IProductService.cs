using ministore.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ministore.business.Services.Interfaces
{
    public interface IProductService
    {
        Task CreateAsync(Product product);
        Task UpdateAsync(Product product);
        Task DeleteAsync(int id);
       
        Task<List<Product>>GetAllAsync();
        
        Task<Product>GetSingleAsync(int id);
        Task SoftDelete(int id);
    }
}
