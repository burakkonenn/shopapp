using app.entity;

namespace app.data.Abstract
{
    public interface ICartRepository: IRepository<Cart>
    {
        Cart GetCartByUserId(string userId);
        void DeleteFromCart(int cartId, int manProductId);
    }
}