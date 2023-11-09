using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class OrderItems
    {
        public int OrderItemsId { get; set; }
        public Product Product { get; set; }
        public int Amount { get; set; }
        public double TotalSum { get; set; }

        public OrderItems()
        {
            
        }
        public OrderItems(Product product, int amount)
        {
            Product = product;
            Amount = amount;
            TotalSum = Product.Price * Amount;
        }

        //public OrderItems(Product product, int amount)
        //{
        //    Product = product;
        //    Amount = amount;
        //}

        public override string? ToString()
        {
            return $"{Amount}x {Product.Description}";
        }


    }
}
