using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class CustomerOrder
    {
        [Key]
        public int CustomerOrderId { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public CustomerOrder(List<OrderItems> orderItems)
        {
            this.OrderItems = orderItems;
        }
        public CustomerOrder()
        {
            
        }
    }
}
