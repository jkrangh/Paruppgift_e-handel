using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public virtual List<CustomerOrder> CustomerOrders { get; set; } = new List<CustomerOrder>();
        //bonus/kundklass-prop

        public override string? ToString()
        {
            return $"Customer ID: [{CustomerId}] Name: {CustomerName}";
        }

    }
}
