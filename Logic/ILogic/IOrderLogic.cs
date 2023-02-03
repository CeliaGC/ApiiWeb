using Entities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.ILogic
{
    public interface IOrderLogic
    {
        int InsertOrder(OrderItem orderItem);
        void UpdateOrder(OrderItem orderItem);
        void DeleteOrder(int id);
        List<OrderItem> GetAllOrders();
        List<OrderItem> GetOrderByUser(int IdUser);
        List<OrderItem> GetOrderByProduct(int IdProduct);

    }
}