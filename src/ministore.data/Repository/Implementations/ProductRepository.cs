using ministore.core.Entities;
using ministore.core.Repositories.Interfaces;
using ministore.data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ministore.data.Repository.Implementations
{
    public class ProductRepository : GenericReposaitory<Product>, IProductRepository
    {
        public ProductRepository(AppDbContext context) : base(context)
        {

        }
    }
}
