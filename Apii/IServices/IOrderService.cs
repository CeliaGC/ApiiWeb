using Entities.Entities;

namespace Apii.IServices
{
    public interface IOrderService
    {
        int InsertOrder(OrderItem orderItem);
        void UpdateOrder(OrderItem orderItem);
        void DeleteOrder(int id);
        List<OrderItem> GetAllOrders();
        List<OrderItem> GetOrderByUser(int IdUser);
        List<OrderItem> GetOrderByProduct(int IdProduct);
    }
}
