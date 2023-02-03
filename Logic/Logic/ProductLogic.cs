using Data;
using Entities;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class ProductLogic : BaseContextLogic, IProductLogic
    {
        public ProductLogic(ServiceContext serviceContext) : base(serviceContext) { }

        void IProductLogic.DeleteProduct(int Id)
            {
            _serviceContext.Products.Remove(_serviceContext.Set<ProductItem>().Where(p => p.Id == Id).FirstOrDefault());
            _serviceContext.SaveChanges();
            }

        public int InsertProductItem(ProductItem productItem)
        {
            _serviceContext.Products.Add(productItem);
            _serviceContext.SaveChanges();
            return productItem.Id;
        }
        public void UpdateProduct(ProductItem productItem) 
        {
            _serviceContext.Products.Update(productItem);
            _serviceContext.SaveChanges();
        }

        public List<ProductItem> GetProductByCriteria(string ProductBrand)
        {
            var brandFilter = new ProductItem();
            brandFilter.ProductBrand = ProductBrand;

            var resultList = _serviceContext.Set<ProductItem>()
                                .Where(p => p.ProductBrand == ProductBrand);

            if (brandFilter.ProductBrand == ProductBrand)
            {
                resultList = resultList.Where(p => p.ProductBrand == ProductBrand);
            }


            return resultList.ToList();
        }

        List<ProductItem> IProductLogic.GetAll()
        {
            var allProducts = _serviceContext.Set<ProductItem>().ToList();
            return allProducts;
        }

       
    }

}
