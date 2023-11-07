using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Paruppgift_e_handel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new Store();

            store.menu
            
            //var customer = store.Customers.FirstOrDefault(c => c.CustomerName == "Janne");


            //var items = new OrderItems() { Product = store.Products.First(x => x.ProductDescription == "Milk, 1L"), Amount = 1 };

            //var shoppingBasket = new List<OrderItems> () { items };

            //var customerOrder = new CustomerOrder() { OrderItems = shoppingBasket };

            

            
            //foreach (var cust in store.Customers.Include(x => x.CustomerOrders).ThenInclude(x => x.OrderItems))
            //{
            //    Console.WriteLine(cust);

            //    foreach (var custorder in cust.CustomerOrders)
            //    {
            //        Console.WriteLine(custorder);

            //        foreach (var order in custorder.OrderItems)
            //        {
            //            Console.WriteLine(order);
            //        }
            //    }
            //}

               
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