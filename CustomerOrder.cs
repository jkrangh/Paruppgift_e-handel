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
        
        public int CustomerOrderId { get; set; }
        public Customer Customer { get; set; }       
        public double TotalSum { get; set; }
        public DateTime OrderCreated { get; set; }
        public bool HasBeenShipped { get; set; } = false;
        public DateTime OrderShipped { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public CustomerOrder()
        {
            
        }
        public CustomerOrder(Customer customer, List<OrderItems> orderItems)
        {
            this.Customer = customer;
            OrderItems = orderItems;
            OrderCreated = DateTime.Now;
            TotalSum = OrderItems.Sum(x => x.TotalSum);
        }

        public override string? ToString()
        {
            return $"Order ID: {CustomerOrderId}";
        }
    }
}
