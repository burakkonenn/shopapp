using System.Linq;
using app.business.Abstract;
using app.webui.Identity;
using app.webui.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace app.webui.Controllers
{
    public class CartController:Controller
    {
        private ICartService _cartService;
        private UserManager<User> _userManager;
        public CartController(ICartService cartService, UserManager<User> userManager)
        {
            this._cartService = cartService;
            this._userManager = userManager;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartById(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel()
                {
                    CartItemModelId = i.Id,
                    ProductId = i.Id,
                    Name = i.ManProduct.Name,
                    Price = (double)i.ManProduct.Price,
                    Image = i.ManProduct.Image,
                    Quantity = i.Quantity
                }).ToList()
            });
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity)
        {
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(productId,quantity,userId);
            return RedirectToAction("Index");
        }
    
    
    }
}