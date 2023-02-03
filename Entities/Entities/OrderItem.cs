
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Entities
{
    public class OrderItem
    {
        public int Id { get; set; }
        public Guid IdWeb { get; set; }
        public DateTime DateOrder { get; set; }
        public int IdUser { get; set; }
        public int IdRol { get; set; }

        public int IdProduct { get; set; }
        public decimal Price { get; set; }

        public int Amount { get; set; }
        public DateTime DeliveryDate { get; set; }
        public bool Delivered { get; set; }
        public bool Paid { get; set; }
        public bool IsActive { get; set; }

    }

}