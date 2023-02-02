using Apii.IServices;
using Entities.Entities;
using Logic.ILogic;

namespace Apii.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductLogic _productLogic;
        public ProductService(IProductLogic productLogic)
        {
            _productLogic = productLogic;
        }
        public int InsertProduct(ProductItem productItem)
        {
            _productLogic.InsertProductItem(productItem);
            return productItem.Id;
        }

        public void DeleteProduct(int Id)
        {
            _productLogic.DeleteProduct(Id);
        }

        public void UpdateProduct(ProductItem productItem) 
        {
            _productLogic.UpdateProduct(productItem);
        }


        List<ProductItem> IProductService.GetProductByCriteria(string ProductBrand)
        {
            return _productLogic.GetProductByCriteria(ProductBrand);
        }

        List<ProductItem> IProductService.GetAll()
        {
            return _productLogic.GetAll();
        }
    }
}