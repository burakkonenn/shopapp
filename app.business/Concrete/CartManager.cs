using app.business.Abstract;
using app.data.Abstract;
using app.entity;

namespace app.business.Concrete
{
    public class CartManager : ICartService
    {
        ICartRepository _cartRepository;
        public CartManager(ICartRepository cartRepository)
        {
            this._cartRepository = cartRepository;
        }

        public void AddToCart(int productId, int quantity,string userId)
        {
            var cart = GetCartById(userId);
            if(cart != null)
            {
                var index = cart.CartItems.FindIndex(i => i.ManProductId==productId);
                if(index<0)
                {
                    cart.CartItems.Add(new CartItem(){
                        CartId = cart.Id,
                        ManProductId = productId,
                        Quantity = quantity,

                    });

                    
                }
                else
                {
                    cart.CartItems[index].Quantity += quantity;
                }
                 _cartRepository.Update(cart);
            }
        }

        public Cart GetCartById(string userId)
        {
            return _cartRepository.GetCartById(userId);
        }

        public void InitializeCart(string userId)
        {
            _cartRepository.Create(new Cart(){UserId = userId});
        }
    }
}