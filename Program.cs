using Microsoft.EntityFrameworkCore;
using System.Reflection;


namespace Paruppgift_e_handel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new Store().Run();
            
            
            //StoreDbContext storeDb = new StoreDbContext();

            //storeDb.Products.Add(new Product() { Description = "Banana", Brand = "Chiquita", Category = Category.Fruit, Price = 3 });
            //storeDb.Products.Add(new Product() { Description = "Apple", Brand = "Montesanto", Category = Category.Fruit, Price = 3.5 });
            //storeDb.Products.Add(new Product() { Description = "Pear", Brand = "Montesanto", Category = Category.Fruit, Price = 4 });
            //storeDb.Products.Add(new Product() { Description = "Lettuce", Brand = "Green farmer", Category = Category.Vegetable, Price = 20 });
            //storeDb.Products.Add(new Product() { Description = "Tomato", Brand = "Grandma Umas", Category = Category.Vegetable, Price = 8 });
            //storeDb.Products.Add(new Product() { Description = "Cucumber", Brand = "Green farmer", Category = Category.Vegetable, Price = 12 });
            //storeDb.Products.Add(new Product() { Description = "Milk", Brand = "Happy cows finest", Category = Category.Dairy, Price = 22 });
            //storeDb.Products.Add(new Product() { Description = "Boellnaesfiel", Brand = "Kavli", Category = Category.Dairy, Price = 28 });
            //storeDb.Products.Add(new Product() { Description = "T-bone steak", Brand = "Furious bull", Category = Category.Meat, Price = 299 });
            //storeDb.Products.Add(new Product() { Description = "Minced beef", Brand = "Belgian blues", Category = Category.Meat, Price = 129 });
            //storeDb.Products.Add(new Product() { Description = "Salmon", Brand = "Norwegian star", Category = Category.Fish, Price = 229 });
            //storeDb.Products.Add(new Product() { Description = "Tuna, canned", Brand = "Skippers canned goods", Category = Category.Fish, Price = 24 });
            //storeDb.Products.Add(new Product() { Description = "Ostridge steak", Brand = "Running birds", Category = Category.Poultry, Price = 239 });
            //storeDb.Products.Add(new Product() { Description = "Chicken, whole", Brand = "Golden rooster", Category = Category.Poultry, Price = 69 });
            //storeDb.SaveChanges();
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