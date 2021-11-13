using app.entity;

namespace app.data.Abstract
{
    public interface ICartRepository: IRepository<Cart>
    {
        Cart GetCartById(string userId);
        
    }
}