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
        private UserManager<User> _userManager;
        private ICartService _cartService;
        public CartController(UserManager<User> userManager, ICartService cartService)
        {
            this._userManager = userManager;
            this._cartService = cartService;
        }
        public IActionResult Index()
        {
            var cart = _cartService.GetCartByUserId(_userManager.GetUserId(User));
            return View(new CartModel()
            {
                CartId = cart.Id,
                CartItems = cart.CartItems.Select(i => new CartItemModel(){
                    CartItemModelId = i.Id,
                    ProductId = i.ManProductId,
                    Name = i.ManProduct.Name,
                    Price = (double)i.ManProduct.Price,
                    Image = i.ManProduct.Image,
                    Quantity = i.Quantity
                
                }).ToList()
            });
        }

        [HttpPost] 
        public IActionResult AddToCart(int manProductId, int quantity){
            var userId = _userManager.GetUserId(User);
            _cartService.AddToCart(userId, manProductId, quantity);
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult DeleteFromCart(int manProductId){
            var userId = _userManager.GetUserId(User);
            _cartService.DeleteFromCart(userId,manProductId);
            return RedirectToAction("Index");
        }
        
    }
}