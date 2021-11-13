using System.Collections.Generic;
using app.business.Abstract;
using app.data.Abstract;
using app.entity;

namespace app.business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        ICategoryRepository _categoryRepository;
        public CategoryManager(ICategoryRepository categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }


        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(MansCategory Entity)
        {
            _categoryRepository.Create(Entity);
        }

        public void Delete(MansCategory Entity)
        {
            _categoryRepository.Delete(Entity);
        }

        public void DeleteFromCategory(int productId, int categoryId)
        {
            _categoryRepository.DeleteFromCategory(productId, categoryId);
        }

        public List<MansCategory> GetAll()
        {
            return _categoryRepository.GetAll();
        }

        public MansCategory GetById(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<MansCategory> GetCategoryByOrder()
        {
            return _categoryRepository.GetCategoryByOrder();
        }

        public MansCategory GetCategoryByProduct(int id)
        {
            return _categoryRepository.GetCategoryByProduct(id);
        }

        public void Update(MansCategory Entity)
        {
            _categoryRepository.Update(Entity);
        }

        public bool Validation(MansCategory Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}