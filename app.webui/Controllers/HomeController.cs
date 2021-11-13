using System.Threading.Tasks;
using app.business.Abstract;
using app.webui.Models;
using Microsoft.AspNetCore.Mvc;
using app.entity;
namespace app.webui.Controllers
{
    public class HomeController:Controller
    {
        private IProductService _productService;
        public HomeController(IProductService productService)
        {
            this._productService = productService;
        }

        public IActionResult Index()
        {
            var model = new ProductModel()
            {
                Products = _productService.GetAll()
            };
           
            return View(model);
        }

        
       
        public IActionResult About()
        {
            return View();
        }
    }
}