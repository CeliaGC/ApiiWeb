
using Data;
using Entities.Entities;
using Entities.OrderRequest;
using Logic.ILogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Logic.Logic
{
    public class OrderLogic : BaseContextLogic, IOrderLogic

    {
    public OrderLogic(ServiceContext serviceContext) : base(serviceContext) { }
    public void DeleteOrder(int id)
        {
            _serviceContext.Orders.Remove(_serviceContext.Set<OrderItem>().Where(o => o.Id == id).FirstOrDefault());
            _serviceContext.SaveChanges();
        }

        public List<OrderItem> GetAllOrders()
        {
            var allOrder = _serviceContext.Set<OrderItem>().ToList();
            return allOrder;

        }

        public List<OrderItem> GetOrderByProduct(int IdProduct)
        {
            var orderFilter = new OrderItem();
            orderFilter.IdProduct = IdProduct;

            var resultList = _serviceContext.Set<OrderItem>()
                                .Where(o => o.IdProduct == IdProduct);

            if (orderFilter.IdProduct == IdProduct)
            {
                resultList = resultList.Where(o => o.IdProduct == IdProduct);
            }


            return resultList.ToList();
        }

        public List<OrderItem> GetOrderByUser(int IdRol)
        {
            var userFilter = new OrderItem();
            userFilter.IdRol = IdRol;

            var resultList = _serviceContext.Set<OrderItem>()
                                .Where(o => o.IdRol == IdRol);

            if (userFilter.IdRol == IdRol)
            {
                resultList = resultList.Where(o => o.IdRol == IdRol);
            }


            return resultList.ToList();
        }

        public int InsertOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Add(orderItem);
            _serviceContext.SaveChanges();
            return orderItem.Id;
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _serviceContext.Orders.Update(orderItem);
            _serviceContext.SaveChanges();
        }
    }
}
