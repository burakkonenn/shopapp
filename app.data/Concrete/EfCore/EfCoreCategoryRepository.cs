using System.Collections.Generic;
using System.Linq;
using app.data.Abstract;
using app.entity;
using Microsoft.EntityFrameworkCore;

namespace app.data.Concrete.EfCore
{
    public class EfCoreCategoryRepository : EfCoreGenericRepository<MansCategory, ShopContext>, ICategoryRepository
    {
               public void DeleteFromCategory(int productId, int categoryId)
        {
            using(var context = new ShopContext())
            {
                var cmd = "delete from productcategory where productId=@p0 and categoryId=@p1";
                context.Database.ExecuteSqlRaw(cmd,productId,categoryId);
            }            
        }


        public List<MansCategory> GetCategoryByOrder()
        {
            using(var context = new ShopContext())
            {
                var cat = from c in context.MansCategories
                                orderby c.Name
                                select c;
                                
                return cat.ToList();
            }
        }

        public MansCategory GetCategoryByProduct(int id)
        {
            using(var context = new ShopContext())
            {
                var categories = context.MansCategories.Where(p => p.Id == id)
                                                 .Include(p => p.ManProducts).FirstOrDefault();
                    return categories;

            }
        }
    }
}