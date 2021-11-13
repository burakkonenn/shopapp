using System.Linq;
using app.entity;
using Microsoft.EntityFrameworkCore;

namespace app.data.Concrete.EfCore
{
    public class SeedDatabase
    {
        public static void Seed()
        {
            var context = new ShopContext();

            if(context.Database.GetPendingMigrations().Count() == 0)
            {
               

              
            }
            context.SaveChanges();
            
            
        }
    


 }

}
