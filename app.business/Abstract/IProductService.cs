using System.Collections.Generic;
using app.entity;

namespace app.business.Abstract
{
    public interface IProductService: IValidator<ManProduct>
    {
        List<ManProduct> GetAll();
        ManProduct GetById(int id);
        void Create(ManProduct Entity);
        void Update(ManProduct Entity);
        void Delete(ManProduct Entity);
        
        int GetBrandTotalCount();
        List<ManProduct> GetProductByDecending();
        List<ManProduct> GetProductByAcending();
        ManProduct GetProduct(int id);
        int GetProductsCount();
        ManProduct GetProductAndCategory(int id);
       

                

        
    }
}