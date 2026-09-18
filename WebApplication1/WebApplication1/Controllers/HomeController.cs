using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ProductService _productService;

        public HomeController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}
