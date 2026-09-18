using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using WebApplication1.Models.Services;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetProducts();
            return View(products);
        }

        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }
    }
}
