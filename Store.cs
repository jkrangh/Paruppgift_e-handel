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
        private readonly string[] menuOptions = { "1. List available products", "2. Create order", "3. List all orders", "4. Edit order",
                                                  "5. Delete order", "6. Edit customer details", "7. Customer logout" };
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
                    menu.PrintList(ListAllProducts());
                    break;
                case 2:
                    //CreateOrder
                    var inventory = ListAllProducts();
                    menu.PrintList(inventory);
                    CreateOrder(AddProductToBasket(inventory), customer);
                    break;
                case 3:
                    //List all orders
                    //var receipt = storeDb.CustomerOrders.Where(x => x.CustomerId == customer.CustomerId).Include(x => x.;
                    var list = storeDb.CustomerOrders.Include(x => x.OrderItems);
                    var listSortedByCustomer = list.Where(x => x.CustomerId == customer.CustomerId);
                    foreach (var custOrder in listSortedByCustomer)
                    {
                        Console.WriteLine(custOrder.OrderItems.ToString());
                    }

                    //foreach (var custOrder in storeDb.CustomerOrders.Where(x => x.CustomerId == customer.CustomerId))
                    //{
                    //    Console.WriteLine(custOrder);
                    //}

                    //foreach (var cust in storeDb.CustomerOrders.
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

                    break;
                case 4:
                    //Edit order ?
                    break;
                case 5:
                    //Delete order

                    //Identify CustOrder to delete.


                    //storeDb.Customer
                    break;
                case 6:
                    //Edit customer details
                    break;
                case 7:
                    //Return to loginMenu.
                    run = false;
                    break;
                default:
                    break;
            }
            return run;
        }

        private List<OrderItems> AddProductToBasket(List<Product> inventory)
        {
            var customerOrderItems = new List<OrderItems>();
            bool run = true;

            while (run)
            {

                OrderItems orderItems = new()
                {
                    Product = inventory[menu.UserIntQuery("Choose product:", 0, inventory.Count()) - 1],
                    //Product = inventory.First(p => p.ProductId == menu.UserIntQuery("Choose product: ", 0, inventory.Count())),
                    Amount = menu.UserIntQuery("Choose amount: ", 0, int.MaxValue)
                };

                customerOrderItems.Insert(0, orderItems);
                menu.PrintList(customerOrderItems);
                run = Convert.ToBoolean(menu.UserIntQuery("Continue shopping (1 = yes, 0 = no)", 0, 1)); // TODO - Fixa så att vi slipper frågan (0 = exit)
                                                                                                         //Place order / Cancel order

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
        }


        private List<Product> ListAllProducts()
        {
            return storeDb.Products.ToList();
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
