using app.entity;

namespace app.business.Abstract
{
    public interface ICartService
    {
        void InitializeCart(string userId);
        Cart GetCartById(string userId);
        void AddToCart(int productId, int quantity,string userId);
    }
}