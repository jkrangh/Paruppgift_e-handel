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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        private string password;
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public virtual List<CustomerOrder> CustomerOrders { get; set; }
        //bonus/kundklass-prop

        public override string? ToString()
        {
            return $"[{CustomerId}] Firstname: {FirstName} Lastname: {LastName}";
        }

    }
}
