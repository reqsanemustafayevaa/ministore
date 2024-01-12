using Microsoft.EntityFrameworkCore;
using ministore.core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ministore.core.Repositories.Interfaces
{
    public interface IProductRepository : IGenericRepository<Product>
    {
       
    }
}
