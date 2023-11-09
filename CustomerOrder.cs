﻿using System;
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
        public int CustomerId { get; set; }
        public double TotalSum { get; set; }
        public List<OrderItems> OrderItems { get; set; }

        public CustomerOrder()
        {
            
        }
        public CustomerOrder(int customerId, List<OrderItems> orderItems)
        {
            CustomerId = customerId;
            OrderItems = orderItems;
            TotalSum = OrderItems.Sum(x => x.TotalSum);
        }

        //TODO: bool IsDelivered: if true, user can't edit or delete order 

        public override string? ToString()
        {
            return $"Order ID: {CustomerOrderId}";
        }
    }
}
