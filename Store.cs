using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class Store
    {
        StoreDbContext storeDb = new StoreDbContext();
        private Menu menu;

        //Menu options:
        private readonly string[] loginOptions = { "1. Customer login", "2. Create new customer", "3. Admin login", "4. Exit" };
        private readonly string[] menuOptions = { "1. List available products", "2. Create order", "3. List all orders",
                                                  "4. Delete order", "5. Edit customer details", "6. Customer logout" };
        private readonly string[] adminOptions = { "1. Manage open customer orders", "2. List all customer orders",
                                                    "3. Add new product", "4. Edit/Delete available products", "5. Admin logout" };

        public Store()
        {
            menu = new Menu(this, loginOptions, menuOptions, adminOptions);
        }

        internal void Run()
        {
            menu.DisplayLoginMenu();
        }
        internal void LoginHandler(int input)
        {
            switch (input)
            {
                case 1:
                    var user = Login(menu.UserLoginQuery());
                    if (user != null)
                    {
                        menu.DisplayMainMenu((Customer)user);
                    }
                    break;
                case 2:
                    menu.DisplayMainMenu(CreateCustomer(menu.GetCustomerDetails()));
                    break;
                case 3:
                    var admin = Login(menu.UserLoginQuery());
                    if (admin != null)
                    {
                        menu.DisplayAdminMenu((Admin)admin);
                    }
                    break;
                case 4:
                    Environment.Exit(0);
                    return;
                default:
                    break;
            }
        }

        internal bool MenuHandler(Customer customer, int input)
        {            
            bool run = true;
            switch (input)
            {
                case 1:
                    //List available products
                    menu.PrintList(ListAllProducts(), 0);
                    break;
                case 2:
                    //CreateOrder
                    var inventory = ListAllProducts();
                    menu.PrintList(inventory, 0);
                    CreateOrder(AddProductToBasket(inventory), customer);
                    break;
                case 3:
                    //List all orders
                    ListOrders(customer);
                    Console.ReadKey();
                    break;
                case 4:

                    DeleteOrder(customer);    //TODO - fixa! Testkört, verkar funka
                    break;
                case 5:
                    //Edit customer details
                    EditCustomer(customer);
                    break;
                case 6:
                    //Return to loginMenu.
                    run = false;
                    break;                
                default:
                    break;
            }
            return run;
        }
        internal bool AdminMenuHandler(Admin admin, int input) // TODO
        {
            //"1. Manage open customer orders", "2. List all customer orders",
            //"3. Add new product", "4. Edit/Delete available products"

            bool run = true;
            switch (input)
            {
                case 1:
                    //List available products
                    menu.PrintList(ListAllProducts(), 0);
                    break;
                case 2:
                    ListOrders(admin);
                    Console.ReadKey();
                    break;
                case 3:
                    menu.GetProductDetails();
                    break;
                case 4:
                    //DeleteOrder(admin);    
                    break;
                case 5:
                    //Return to loginMenu.
                    run = false;
                    break;                                  
                default:
                    break;
            }
            return run;
        }

        private void EditCustomer(Customer customer)
        {
            var customerDetails = menu.GetCustomerDetails();
            customer.FirstName = customerDetails[0];
            customer.LastName = customerDetails[1];
            customer.Address = customerDetails[2];
            customer.Phone = customerDetails[3];
            customer.Email = customerDetails[4];
            customer.Password = customerDetails[5];
            storeDb.SaveChanges();
        }

        private List<OrderItems> AddProductToBasket(List<Product> inventory)
        {
            var customerOrderItems = new List<OrderItems>();
            bool run = true;

            while (run)
            {
                int input = menu.UserIntQuery("Choose product:", 0, inventory.Count());
                if (input == 0)
                {
                    run = false;
                    break;
                }
                var product = inventory[input - 1];
                var amount = menu.UserIntQuery("Choose amount: ", 0, int.MaxValue);
                OrderItems orderItems = new(product, amount);

                customerOrderItems.Insert(0, orderItems);
                double price = customerOrderItems.Sum(x => x.TotalSum);
                menu.PrintList(customerOrderItems, price);
                //run = Convert.ToBoolean(menu.UserIntQuery("Continue shopping (1 = yes, 0 = no)", 0, 1));


            }
            return customerOrderItems;
        }
        private Customer CreateCustomer(string[] customerDetails)
        {
            var customer = new Customer()
            {
                FirstName = customerDetails[0],
                LastName = customerDetails[1],
                Address = customerDetails[2],
                Phone = customerDetails[3],
                Email = customerDetails[4],
                Password = customerDetails[5],
            };
            storeDb.Customers.Add(customer);
            storeDb.SaveChanges();
            return customer;
        }
        private void CreateOrder(List<OrderItems> shoppingBasket, Customer customer)
        {
            var customerOrder = new CustomerOrder(customer, shoppingBasket);
            storeDb.CustomerOrders.Add(customerOrder);
            storeDb.SaveChanges();
            Console.WriteLine($"{customerOrder} was placed successfully!");
        }


        private List<Product> ListAllProducts()
        {
            return storeDb.Products.ToList();
        }

        internal void ListOrders(Customer customer)
        {
                Console.WriteLine($"All orders placed by {customer.FirstName} {customer.LastName}");
                foreach (var customerOrder in storeDb.CustomerOrders.Where(x => x.Customer.CustomerId == customer.CustomerId).Include(x => x.OrderItems).ThenInclude(x => x.Product))
                {
                    Console.WriteLine($"Order ID: {customerOrder.CustomerOrderId} Total: {customerOrder.OrderItems.Sum(x => x.TotalSum)}SEK");

                    foreach (var item in customerOrder.OrderItems)
                    {
                        Console.WriteLine(item);
                    }
                }
        }
        internal void ListOrders(Admin admin)
        {

            Console.WriteLine($"All open orders");
            foreach (var customerOrder in storeDb.CustomerOrders.OrderBy(x => x.HasBeenShipped).Include(x => x.OrderItems).ThenInclude(x => x.Product))
            {
                string status = customerOrder.HasBeenShipped ? "Shipped" : "Open";

                Console.WriteLine($"Order ID: {customerOrder.CustomerOrderId} Status: {status} Received: {customerOrder.OrderCreated} Total: {customerOrder.OrderItems.Sum(x => x.TotalSum)}SEK");

                foreach (var item in customerOrder.OrderItems)
                {
                    Console.WriteLine(item);
                }
            }

        }
        internal void DeleteOrder(Customer customer)
        {
            ListOrders(customer);
            int orderIdToDelete = menu.UserIntQuery("Choose order to delete: ", 0, int.MaxValue);
            var order = storeDb.CustomerOrders.Where(x => x.Customer.CustomerId == customer.CustomerId).FirstOrDefault(x => x.CustomerOrderId == orderIdToDelete);
            if(order != default)
            {
                storeDb.CustomerOrders.Remove(order);
                storeDb.SaveChanges();
            }
            else
            {
                menu.EntryFail();
            }
        }

        public object Login(string[] userCredentials)
        {
            object user = storeDb.Customers.FirstOrDefault(c => c.Email == userCredentials[0] && c.Password == userCredentials[1]);

            if (user == default)
            {
                user = storeDb.Admins.FirstOrDefault(c => c.Email == userCredentials[0] && c.Password == userCredentials[1]);                
                //customerCredentials = menu.CustomerLoginQuery();
            }
            if (user != default)
            {
                return user;

            }

            return null;
        }

        //public Admin Login(string[] adminCredentials)
        //{


        //    var customer = storeDb.Customers.FirstOrDefault(c => c.Email == customerCredentials[0] && c.Password == customerCredentials[1]);

        //    if (customer == default)
        //    {
        //        menu.PrintLoginFail();
        //        //customerCredentials = menu.CustomerLoginQuery();
        //    }
        //    else if (customer != default)
        //    {
        //        return customer;

        //    }

        //    return null;
        //}

        internal void AddProduct(string description, string brand, Category category, double price)
        {
            var newProduct = new Product()
            {
                Description = description,
                Brand = brand,
                Category = category,
                Price = price                
            };
            storeDb.Products.Add(newProduct);
            storeDb.SaveChanges();            
        }

    }
}
