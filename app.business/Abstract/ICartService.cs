using app.entity;

namespace app.business.Abstract
{
    public interface ICartService
    {
        void InitiliazeCart(string userId);   

        Cart GetCartByUserId(string userId);
        void AddToCart(string userId, int manProductId, int quantity);
        void DeleteFromCart(string userId, int manProductId);
        
    }
}