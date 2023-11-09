using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    public enum Category
    {
        Fruit =1,
        Vegetable,
        Dairy,
        Meat,
        Fish,
        Poultry
    }

    internal class Product
    {
        public int ProductId { get; set; }
        public string Description { get; set; } = null!;
        public string Brand { get; set; } = "";
        [Column(TypeName = "nvarchar(24)")]     //Force enum to string conversion.
        public Category Category { get; set; }
        public double Price { get; set; }

        public override string? ToString()
        {
            return $"Description: {Description}\t\tBrand: {Brand}\t\tCategory: {Category}\t\tPrice: {Price}";
        }

        //public string ProductAmountPerPack { get; set; }


    }
}
