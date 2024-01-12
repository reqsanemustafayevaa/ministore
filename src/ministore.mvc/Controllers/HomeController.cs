using Microsoft.AspNetCore.Mvc;
using ministore.mvc.Models;
using System.Diagnostics;

namespace ministore.mvc.Controllers
{
    
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            return View();
        }

      
    }
}