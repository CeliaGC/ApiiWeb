using Entities;
using Entities.Entities;

namespace Apii.IServices
{
    public interface IProductService
    {
        int InsertProduct(ProductItem productItem);

        void DeleteProduct(int Id);

        void UpdateProduct(ProductItem productItem);

        List<ProductItem> GetProductByCriteria(string ProductBrand);
        List<ProductItem> GetAll();
    }

    
}
