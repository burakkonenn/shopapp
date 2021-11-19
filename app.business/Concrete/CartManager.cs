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

        public void AddToCart(string userId, int manProductId, int quantity)
        {
            var cart = GetCartByUserId(userId);
            if(cart != null)
            {
                var Index = cart.CartItems.FindIndex(i => i.ManProductId == manProductId);
                if(Index<0)
                {
                    cart.CartItems.Add(new CartItem(){
                       CartId = cart.Id,
                       ManProductId = manProductId,
                       Quantity = quantity,
                 
                       
                    });
                }
                else{
                    cart.CartItems[Index].Quantity += quantity;
                }
                 _cartRepository.Update(cart);
            }
           
        }

        public void DeleteFromCart(string userId, int manProductId)
        {
            var cart = GetCartByUserId(userId);
            if(cart != null)
            {
                _cartRepository.DeleteFromCart(cart.Id, manProductId);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            return _cartRepository.GetCartByUserId(userId);
        }

        public void InitiliazeCart(string userId)
        {
            _cartRepository.Create(new Cart(){UserId = userId});
        }

       
    }
}