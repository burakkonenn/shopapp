using System.Linq;
using app.business.Abstract;
using app.data.Concrete.EfCore;
using app.entity;
using app.webui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace app.webui.Controllers
{
    public class ShopController : Controller
    {
        private IProductService _productService;
        private ICategoryService _categoryService;
        public ShopController(IProductService productService, ICategoryService categoryService)
        {
            this._productService = productService;
            this._categoryService = categoryService;

        }

        ShopContext context = new ShopContext();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Man()
        {
            var model = new ProductModel()
            {
                TotalCount = _productService.GetBrandTotalCount(),
                Products = _productService.GetProductByDecending()

            };

            return View(model);
        }

        public IActionResult ManCategories(string url)
        {
            if(url == null)
            {
                return NotFound();
            }
            var entity = context.ManProducts.Include(i => i.MansCategory).Where(i => i.MansCategory.Url==url).ToList();
            ViewBag.Brands = context.MansBrands.ToList();

            return View(entity);

        }

        public IActionResult ManBrandDetails(string url)
        {
            var model = context.ManProducts.Include(i => i.MansBrands).Where(i => i.MansBrands.Url==url).ToList();
            ViewBag.Bodies = context.Body.ToList();
            ViewBag.Brands = context.MansBrands.ToList();


            return View(model);
        }
        public IActionResult ManBodies(string url)
        {
            var model = context.ManProducts.Include(i => i.ManProductBodies).ThenInclude(i => i.Body).Where(i => i.ManProductBodies.Any(i => i.Body.Url == url)).ToList();
            ViewBag.Bodies = context.Body.ToList();
            ViewBag.Brands = context.MansBrands.ToList();

            return View(model);
        }




        public IActionResult Details(int? id, int Id)
        {

            if (id == null)
            {
                return NotFound();
            }
            var product = _productService.GetProduct((int)id);
            
            if (product == null)
            {
                return NotFound();
            }
            var comment = context.Comment.Where(i => i.ProductId == Id).ToList();
            var totalCount = context.Comment.Where(i => i.ProductId == id).Count();

            var model = new ProductDetailModel()
            {
                Product = product,
                Comments = comment,
                totalCommentCount = totalCount
            };
            return View(model);
        }

        public IActionResult Comment()
        {

            return View();
        }
        
        [HttpPost]
        public IActionResult Comment(Comments model)
        {
            
            context.Add(model);
            context.SaveChanges();

            return RedirectToAction("Index");

        }
        public IActionResult Like(int id)
        {
            Comments like = context.Comment.ToList().Find(i => i.Id == id);
            like.Like += 1;
            context.SaveChanges();
            return RedirectToAction("Index");
        }





        public IActionResult Decending()
        {
            
            return View();
        }
        public IActionResult Acending()
        {
            var model = new ProductModel()
            {
                Pro = _productService.GetProductByAcending()
            };
            return View(model);
        }











    }
}