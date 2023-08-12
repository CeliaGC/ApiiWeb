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
        //public int Id { get; set; }
        //public Guid IdWeb { get; set; }
        //public DateTime DateOrder { get; set; }
        //public int IdUser { get; set; }
        public string UserPassword { get; set; }
        //public int IdRol { get; set; }

        public int IdProduct { get; set; }
        //public decimal Price { get; set; }
        public int Amount { get; set; }
        //public decimal Discount { get; private set; }
        //public decimal FinalPrice { get; set; }

        //public DateTime DeliveryDate { get; private set; }
        //public bool Delivered { get; set; }
        //public bool Paid { get; set; }
        //public bool IsActive { get; set; }


        public OrderItem ToOrderItem()
        {
          
            var newOrderItem = new OrderItem();

            newOrderItem.IdWeb = new Guid();
            newOrderItem.IdProduct = IdProduct;
            newOrderItem.DateOrder = DateTime.Now;
            //newOrderItem.IdUser = IdUser;
            //newOrderItem.IdRol = IdRol;
      
            newOrderItem.Amount = Amount;


            //newOrderItem.Price = Price;

            //if (newOrderItem.IdRol == 2)
            //{
            //    newOrderItem.Discount = 0.1M * (Amount * Price);
            //}
            //else if (newOrderItem.IdRol == 3)
            //{
            //    newOrderItem.Discount = 0.15M * (Amount * Price);
            //}


            //else if (newOrderItem.IdTipoCliente == 3)
            //{
            //    newOrderItem.Discount = 0.2M * (Cantidad * Precio);
            //}
            //else
            //{
            //    newOrderItem.Discount = 0;
            //}

            //if (newOrderItem.IdRol == 2)
            //{
            //    newOrderItem.FinalPrice = 0.9M * (Amount * Price);
            //}
            //else if (newOrderItem.IdRol == 3)
            //{
            //    newOrderItem.FinalPrice = 0.85M * (Amount * Price);
            //}
            //else if (pedidoItem.IdTipoCliente == 3)
            //{
            //    pedidoItem.ImporteTotal = 0.8M * (Cantidad * Precio);
            //}
            //else
            //{
            //    newOrderItem.FinalPrice = Amount * Price;
            //}
            //pedidoItem.ImporteTotal = (Cantidad * Precio) - pedidoItem.Descuento;

            newOrderItem.DeliveryDate =DateTime.MaxValue;
            newOrderItem.Paid = false;
            newOrderItem.Delivered = false;
            newOrderItem.IsActive = true;

            return newOrderItem;

            //buscas en base el producto y su precio.
        }
    }
}

