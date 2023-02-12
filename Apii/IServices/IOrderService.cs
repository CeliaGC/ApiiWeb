using Entities.Entities;
using Entities.OrderRequest;

namespace Apii.IServices
{
    public interface IOrderService
    {
        int InsertOrder(newOrderRequest newOrderRequest);
        void UpdateOrder(OrderItem orderItem);
        void DeleteOrder(int id);
        List<OrderItem> GetAllOrders();
        List<OrderItem> GetOrderByUser(int IdUser);
        List<OrderItem> GetOrderByProduct(int IdProduct);
    }
}
