using System.Collections.Generic;
using System.Linq;
using app.data.Abstract;
using app.entity;
using Microsoft.EntityFrameworkCore;

namespace app.data.Concrete.EfCore
{
    public class EfCoreProductRepository : EfCoreGenericRepository<ManProduct, ShopContext>, IProductRepository
    {
       

        public int GetBrandTotalCount()
        {
            using( var context = new ShopContext())
            {
                var product = context.MansBrands.Count();
                return product;
            }
        }

        public ManProduct GetProduct(int id)
        {
            using(var context = new ShopContext())
            {
                return context.ManProducts.Where(p => p.Id == id)
                                        //   .Include(i => i.Gender)
                                          .Include(i => i.MansBrands)
                                          .Include(i => i.Comments)
                                          .Include(p => p.MansCategory).FirstOrDefault();
                                        
                
                
            }
        }

        public ManProduct GetProductAndCategory(int id)
        {
            using(var context = new ShopContext())
            {
                return context.ManProducts.Where(p => p.Id == id).FirstOrDefault();
                
                
            }           
        }

        public List<ManProduct> GetProductByAcending()
        {
            using(var context = new ShopContext())
            {
                return context.ManProducts.OrderBy(i => i.Price).ToList();
            }

        }


        public List<ManProduct> GetProductByDecending()
        {
            using(var context = new ShopContext())
            {
                var products = context.ManProducts.OrderByDescending(p => p.Price);
                                return products.ToList();
                   
                                
            }
        }

        public int GetProductsCount()
        {
            using(var context = new ShopContext())
            {
                return context.ManProducts.Count();
            }
        }

    }
}