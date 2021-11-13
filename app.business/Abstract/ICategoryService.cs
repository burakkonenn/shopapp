using System.Collections.Generic;
using app.entity;

namespace app.business.Abstract
{
    public interface ICategoryService: IValidator<MansCategory>
    {
        List<MansCategory> GetAll();
        MansCategory GetById(int id);
        void Create(MansCategory Entity);
        void Update(MansCategory Entity);
        void Delete(MansCategory Entity);
        MansCategory GetCategoryByProduct(int id);
        void DeleteFromCategory(int productId, int categoryId);
        List<MansCategory> GetCategoryByOrder();
    


        


    }
}