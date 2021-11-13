using System.Collections.Generic;
using app.entity;

namespace app.data.Abstract
{
    public interface ICategoryRepository: IRepository<MansCategory>
    {
        MansCategory GetCategoryByProduct(int id);
        void DeleteFromCategory(int productId, int categoryId);
        List<MansCategory> GetCategoryByOrder();
    }
}