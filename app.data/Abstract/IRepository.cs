using System.Collections.Generic;
using app.entity;

namespace app.data.Abstract
{
    public interface IRepository<T>
    {
        List<T> GetAll();
        T GetById(int id);
        void Create(T Entity);
        void Update(T Entity);
        void Delete(T Entity);

        

    }
}