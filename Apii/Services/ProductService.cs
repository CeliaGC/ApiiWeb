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

    }
}