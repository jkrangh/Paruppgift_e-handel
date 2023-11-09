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
        private readonly string[] loginOptions = { "1. Customer login", "2. Create new customer", "3. Exit" };
        private readonly string[] menuOptions = { "1. List available products", "2. Create order", "3. List all orders",
                                                  "4. Delete order", "5. Edit customer details", "6. Customer logout" };
        public Store()
        {
            menu = new Menu(this, loginOptions, menuOptions);
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
                    var customer = Login(menu.UserLoginQuery());
                    if (customer != null)
                    {
                        menu.DisplayMainMenu(customer);
                    }
                    break;
                case 2:
                    menu.DisplayMainMenu(CreateCustomer(menu.GetCustomerDetails()));
                    break;
                case 3:
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

        //private void DeleteOrder(Customer customer)
        //{
        //    ListOrders(customer);

        //    int ordersPlaced = storeDb.CustomerOrders.Where(x => x.CustomerId == customer.CustomerId).Count();
        //    Console.WriteLine(ordersPlaced);
        //    int id = menu.UserIntQuery("Enter order ID to delete:", 0, ordersPlaced);

        //}

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
            var customerOrder = new CustomerOrder(customer.CustomerId, shoppingBasket);
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
            foreach (var customerOrder in storeDb.CustomerOrders.Where(x => x.CustomerId == customer.CustomerId).Include(x => x.OrderItems).ThenInclude(x => x.Product))
            {
                Console.WriteLine($"Order ID: {customerOrder.CustomerOrderId} Total cost: {customerOrder.OrderItems.Sum(x => x.TotalSum)}SEK");

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
            var order = storeDb.CustomerOrders.FirstOrDefault(x => x.CustomerOrderId == orderIdToDelete);
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

        public Customer Login(string[] customerCredentials)
        {


            var customer = storeDb.Customers.FirstOrDefault(c => c.Email == customerCredentials[0] && c.Password == customerCredentials[1]);

            if (customer == default)
            {
                menu.PrintLoginFail();
                //customerCredentials = menu.CustomerLoginQuery();
            }
            else if (customer != default)
            {
                return customer;

            }

            return null;
        }
                
    }
}
