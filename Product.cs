using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class Product
    {
        public Product()
        {
        
        }
        public int ProductId { get; set; }
        public string ProductDescription { get; set; }
        public string ProductBrand { get; set; }
        public string ProductCategory { get; set; }
        public double ProductPrice { get; set; }

        public override string? ToString()
        {
            return $"[{ProductId}] {ProductDescription}, {ProductPrice}:-";
        }

        //public string ProductAmountPerPack { get; set; }


    }
}
