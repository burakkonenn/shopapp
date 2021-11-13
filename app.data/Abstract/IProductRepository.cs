using System.Collections.Generic;
using app.entity;

namespace app.data.Abstract
{
    public interface IProductRepository: IRepository<ManProduct>
    {
        int GetBrandTotalCount();
        List<ManProduct> GetProductByDecending();
        ManProduct GetProduct(int id);
        List<ManProduct> GetProductByAcending();
        int GetProductsCount();
        ManProduct GetProductAndCategory(int id);
        
    }
}