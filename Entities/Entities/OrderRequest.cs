using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Entities.OrderRequest
{
    [Keyless]
    public class newOrderRequest
    {
        public string UserPassword { get; set; }
        public int IdProduct { get; set; }
        public int Amount { get; set; }
        public OrderItem ToOrderItem()
        {
          
            var newOrderItem = new OrderItem();

            //newOrderItem.IdWeb = new Guid();
            newOrderItem.IdProduct = IdProduct;
            //newOrderItem.DateOrder = DateTime.Now;
            newOrderItem.Amount = Amount;
            //newOrderItem.DeliveryDate =DateTime.MaxValue;
            //newOrderItem.Paid = false;
            //newOrderItem.Delivered = false;
            //newOrderItem.IsActive = true;

            return newOrderItem;

        }
    }
}

