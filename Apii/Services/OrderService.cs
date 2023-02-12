using Apii.IServices;
using Entities.Entities;
using Entities.OrderRequest;
using Logic.ILogic;

namespace Apii.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderLogic _orderLogic;
        public OrderService(IOrderLogic orderLogic)
        {
            _orderLogic = orderLogic;
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
            var newOrderItem = newOrderRequest.ToOrderItem();
            return _orderLogic.InsertOrder(newOrderItem);
            
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _orderLogic.UpdateOrder(orderItem);
        }
    }
}
