using Apii.IServices;
using Entities.Entities;
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

        public int InsertOrder(OrderItem orderItem)
        {
            _orderLogic.InsertOrder(orderItem);
            return orderItem.Id;
        }

        public void UpdateOrder(OrderItem orderItem)
        {
            _orderLogic.UpdateOrder(orderItem);
        }
    }
}
