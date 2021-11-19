using System.Linq;
using app.data.Abstract;
using app.entity;
using Microsoft.EntityFrameworkCore;

namespace app.data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart, ShopContext>, ICartRepository
    {
        public void DeleteFromCart(int cartId, int manProductId)
        {
            using(var context = new ShopContext())
            {
                var cmd = @"delete from cartItems where CartId=@p0 and ManProductId=@p1";
                context.Database.ExecuteSqlRaw(cmd,cartId,manProductId);
            }
        }

        public Cart GetCartByUserId(string userId)
        {
            using(var context = new ShopContext())
            {
                return context.Carts.Include(i => i.CartItems)
                                    .ThenInclude(i => i.ManProduct)
                                    .FirstOrDefault(i => i.UserId == userId);
            }
        }
        public override void Update(Cart entity)
        {
            using (var context = new ShopContext())
            {
               context.Carts.Update(entity);
               context.SaveChanges();
            }
        } 
      
    }
}