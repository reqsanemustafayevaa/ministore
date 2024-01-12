using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using ministore.business.CustomException;
using ministore.business.Extentions;
using ministore.business.Services.Interfaces;
using ministore.core.Entities;
using ministore.core.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ministore.business.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IWebHostEnvironment _env;

        public ProductService(IProductRepository productRepository
                              ,IWebHostEnvironment env)
        {
            _productRepository = productRepository;
            _env = env;
        }
        public  async Task CreateAsync(Product product)
        {
            if(product == null)
            {
                throw new InvalidNullRefererenceException("Product null olamaz!");

            }
            if(product.ImageFile is not null)
            {
                if(product.ImageFile.ContentType !="image/png" && product.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidContentypeException("ImageFile","file must be .png or .jpeg!");
                }
                if (product.ImageFile.Length > 209624)
                {
                    throw new InvalidImageSizeException("ImageFile", "file must be lower than 1mb!");
                }

            }
            product.ImageUrl = product.ImageFile.SaveFile(_env.WebRootPath, "uploads/products");
            product.CreatedDate= DateTime.UtcNow;
            product.UpdatedDate=DateTime.UtcNow;
            await _productRepository.CreateAsync(product);
            await _productRepository.CommitAsync();
        }

        public async Task DeleteAsync(int id)
        {
            if (id < 0)
            {
                throw new IdBelowZeroException("Id 0 dan kicik olamaz!");
            }
            var existprduct=await _productRepository.GetSingleAsync(x=>x.Id==id);
            if (existprduct == null)
            {
                throw new InvalidNullRefererenceException("Id null olamaz!");
            }
            _productRepository.Delete(existprduct);
            await _productRepository.CommitAsync();
        }

       

        public async Task<List<Product>> GetAllAsync()
        {
            return await _productRepository.GetAllAsync().ToListAsync();
        }

       

      

        public async Task<Product> GetSingleAsync(int id)
        {
            var existproduct =await  _productRepository.GetSingleAsync(x => x.Id == id);
            if (existproduct == null)
            {
                throw new InvalidNullRefererenceException("null olamaz!");
            }
            return existproduct;
            

           
        }

        public async Task SoftDelete(int id)
        {
            if (id < 0)
            {
                throw new IdBelowZeroException("Id 0 dan kicik olamaz!");
            }
            var existprduct = await _productRepository.GetSingleAsync(x => x.Id == id);
            if (existprduct == null)
            {
                throw new InvalidNullRefererenceException("Id null olamaz!");
            }
            existprduct.IsDeleted = !existprduct.IsDeleted;
            await _productRepository.CommitAsync();
        }

        public async Task UpdateAsync(Product product)
        {
            if (product == null)
            {
                throw new InvalidNullRefererenceException("Product null olamaz!");

            }
            var existproduct=await _productRepository.GetSingleAsync(x=>x.Id==product.Id && product.IsDeleted==false);
            if(existproduct is null)
            {
                throw new InvalidNullRefererenceException("product not found!");
            }
            if (product.ImageFile is not null)
            {
                if (product.ImageFile.ContentType != "image/png" && product.ImageFile.ContentType != "image/jpeg")
                {
                    throw new InvalidContentypeException("ImageFile", "file must be .png or .jpeg!");
                }
                if (product.ImageFile.Length > 209624)
                {
                    throw new InvalidImageSizeException("ImageFile", "file must be lower than 1mb!");
                }
                Helper.DeleteFile(_env.WebRootPath, "uploads/products", existproduct.ImageUrl);
                existproduct.ImageUrl = product.ImageFile.SaveFile(_env.WebRootPath, "uploads/products");

            }
            existproduct.Name = product.Name;
            existproduct.Description = product.Description;
            existproduct.UpdatedDate = DateTime.UtcNow;
            await _productRepository.CommitAsync();
            

        }
    }
}
