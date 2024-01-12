using Microsoft.AspNetCore.Mvc;
using ministore.business.CustomException;
using ministore.business.Services.Interfaces;
using ministore.core.Entities;
using ministore.core.Repositories.Interfaces;

namespace ministore.mvc.Areas.manage.Controllers
{
    [Area("manage")]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllAsync();
            return View(products);
        }
        public IActionResult CreateAsync()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAsync(Product product)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Product","product tapilmadi");
                return View();
            }
            try
            {
                 await _productService.CreateAsync(product);
            }
            catch(InvalidNullRefererenceException ex)
            {
                throw new InvalidNullRefererenceException(ex.Message);
            }
            catch(InvalidContentypeException ex)
            {
                throw new InvalidContentypeException(ex.Message,ex.Propertyname);

            }
            catch(InvalidImageSizeException ex)
            {
                throw new InvalidImageSizeException(ex.Message,ex.Propertyname);
            }
            return RedirectToAction("Index");
           
        }
        public IActionResult UpdateAsync(int id)
        {
            var existproduct=_productService.GetSingleAsync(id);
            if (existproduct == null)
            {
                throw new InvalidNullRefererenceException("tapilmadi!");
            }
            return View(existproduct);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateAsync(Product product)
        {

            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("Product", "product tapilmadi");
                return View();
            }
            try
            {
                await _productService.UpdateAsync(product);
            }
            catch (InvalidNullRefererenceException ex)
            {
                throw new InvalidNullRefererenceException(ex.Message);
            }
            catch (InvalidContentypeException ex)
            {
                throw new InvalidContentypeException(ex.Message, ex.Propertyname);

            }
            catch (InvalidImageSizeException ex)
            {
                throw new InvalidImageSizeException(ex.Message, ex.Propertyname);
            }
            return RedirectToAction("Index");

        }
    }
}
