using System.Linq;
using app.data.Abstract;
using app.entity;
using Microsoft.EntityFrameworkCore;

namespace app.data.Concrete.EfCore
{
    public class EfCoreCartRepository : EfCoreGenericRepository<Cart, ShopContext>, ICartRepository
    {
        public Cart GetCartById(string userId)
        {
            using(var context = new ShopContext())
            {
                return context.Carts.Include(c => c.CartItems)     
                                    .ThenInclude(p => p.ManProduct)
                                    .FirstOrDefault(u => u.UserId == userId);
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