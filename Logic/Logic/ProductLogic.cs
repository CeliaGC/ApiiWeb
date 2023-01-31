using Data;
using Entities.Entities;
using Logic.ILogic;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
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
          

    }

}