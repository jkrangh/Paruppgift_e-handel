using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Paruppgift_e_handel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            StoreDbContext store = new StoreDbContext();

            ////Product
            //var milk = new Product() { ProductDescription = "Milk, 1L", ProductBrand = "Dairyfarmers finest", ProductCategory = "Dairy", ProductPrice = 20.5 };

            ////Customer
            //var Janne = new Customer() { CustomerName = "Janne", CustomerAddress = "Stekarvägen 10", CustomerEmail = "janne@stekare.se", CustomerPhone = "070 - 555 666" };

            //store.Products.Add(milk);
            //store.Customers.Add(Janne);
            //store.SaveChanges();


            foreach (var product in store.Products) /*System.InvalidOperationException: 'No suitable constructor was found for entity type 'CustomerOrder'. The following constructors had parameters that could not be bound to properties of the entity type: 
                                                    Cannot bind 'orderItems' in 'CustomerOrder(OrderItems orderItems)'
                                                    Note that only mapped properties can be bound to constructor parameters. Navigations to related entities, including references to owned types, cannot be bound.'
                                                    
                                                    Gjorde en tom constructor i CustomerOrder, då fungerade det ¯\_(ツ)_/¯
                                                    */
            {
                Console.WriteLine(product.ToString());
            }
            foreach (var customer in store.Customers)
            {
                Console.WriteLine(customer.ToString());
            }


            //var shoppingBasket = new OrderItems(store.Products.Where(x => x.ProductDescription == "milk", 3);
            //shoppingBasket.CustomerOrderProducts.Add(milk);


            //var customerOrder = new CustomerOrder(shoppingBasket);

            //store.CustomerOrders.Add(customerOrder);
            //store.SaveChanges();
               
        }
    }
}
            /*Tillsammans ska ni skapa en databas med hjälp av EF code first, som ska hjälpa en e-handel.

            Ni behöver skapa klasser för:
            Kunder
            Order
            OrderItems
            Produkter
            Tabellerna ska vara kopplade i den ordningen som de står ovan.
            Tänk på att det kan vara 1 till många relationer.
            
            Varning Order är ju samma ord som finns i t.ex.Linq för att sortera. 
            Ett tipps för den som inte vill ha problem är att kalla klassen något annat än order.*/