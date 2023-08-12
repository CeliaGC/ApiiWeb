using Apii.IServices;
using Entities.Entities;
using Entities.OrderRequest;
using Logic.ILogic;
using Data;

namespace Apii.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderLogic _orderLogic;
        private readonly ServiceContext _serviceContext;
        public OrderService(IOrderLogic orderLogic, ServiceContext servicecontext)
        {
            _orderLogic = orderLogic;
            _serviceContext = servicecontext;
        }
        public void DeleteOrder(int id)
        {
            _orderLogic.DeleteOrder(id);
        }

        public List<OrderItem> GetAllOrders()
        {
            return _orderLogic.GetAllOrders();
        }

        public List<OrderItem> GetOrderByProduct(int IdProduct)
        {
            return _orderLogic.GetOrderByProduct(IdProduct);
        }

        public List<OrderItem> GetOrderByUser(int IdUser)
        {
            return _orderLogic.GetOrderByUser(IdUser);
        }

        public int InsertOrder(newOrderRequest newOrderRequest)
        {
            
            var userOrdering = _serviceContext.Set<UserItem>()
                                              .Where(u => u.Password == newOrderRequest.UserPassword)
                                              .FirstOrDefault();
            var productOrdered = _serviceContext.Set<ProductItem>()
                                                .Where(p => p.Id == newOrderRequest.IdProduct)
                                                .FirstOrDefault();
            var newOrderItem = newOrderRequest.ToOrderItem();
                {
                newOrderItem.Price = productOrdered.RawPrice;
                newOrderItem.IdUser = userOrdering.Id;
                newOrderItem.IdRol = userOrdering.IdRol;
                newOrderItem.Amount = newOrderRequest.Amount;


           

                if (newOrderItem.IdRol == 2)
                {
                    newOrderItem.Discount = 0.1M * (newOrderItem.Amount * productOrdered.RawPrice);
                }
                else if (newOrderItem.IdRol == 3)
                {
                    newOrderItem.Discount = 0.15M * (newOrderItem.Amount * productOrdered.RawPrice);
                }
                else
                {
                    newOrderItem.Discount = 0;
                }

                if (newOrderItem.IdRol == 2)
                {
                    newOrderItem.FinalPrice = 0.9M * (newOrderItem.Amount * productOrdered.RawPrice);
                }
                else if (newOrderItem.IdRol == 3)
                {
                    newOrderItem.FinalPrice = 0.85M * (newOrderItem.Amount * productOrdered.RawPrice);
                }
                else
                {
                    newOrderItem.FinalPrice = newOrderItem.Amount * productOrdered.RawPrice;
                }
            };
            return _orderLogic.InsertOrder(newOrderItem);
            
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _orderLogic.UpdateOrder(orderItem);
        }
    }
}
