using System.Collections.Generic;
using app.business.Abstract;
using app.data.Abstract;
using app.entity;

namespace app.business.Concrete
{

    public class ProductManager : IProductService
    {
        
        private IProductRepository _productRepository;
        public ProductManager(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
            
        }



        public string ErrorMessage { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

        public void Create(ManProduct Entity)
        {
            _productRepository.Create(Entity);
        }

        public void Delete(ManProduct Entity)
        {
            _productRepository.Delete(Entity);
        }

        public List<ManProduct> GetAll()
        {
            return _productRepository.GetAll();
        }

        public int GetBrandTotalCount()
        {
            return _productRepository.GetBrandTotalCount();
        }

        public ManProduct GetById(int id)
        {
            return _productRepository.GetById(id);
        }

        public ManProduct GetProduct(int id)
        {
            return _productRepository.GetProduct(id);
        }

        public ManProduct GetProductAndCategory(int id)
        {
            return _productRepository.GetProductAndCategory(id);
        }

        public List<ManProduct> GetProductByAcending()
        {
            return _productRepository.GetProductByAcending();
        }

      

        public List<ManProduct> GetProductByDecending()
        {
            return _productRepository.GetProductByDecending();
        }

        public int GetProductsCount()
        {
            return _productRepository.GetProductsCount();
        }

        public void Update(ManProduct Entity)
        {
            _productRepository.Update(Entity);
        }

      
        public bool Validation(ManProduct Entity)
        {
            throw new System.NotImplementedException();
        }
    }
}