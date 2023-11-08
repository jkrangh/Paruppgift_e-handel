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
        private readonly string[] menuOptions = { "1. Create order", "2. List available products", "3. List all orders", "4. Edit order",
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
                    var customer = Login(menu.CustomerLoginQuery());
                    if (customer != null)
                    {
                        menu.DisplayMainMenu(customer);
                    }
                    break;
                case 2:
                    //MenuHandler(CreateCustomer(), GetIntFromUser)
                    break;
                case 3:
                    Environment.Exit(0);
                    return;
                default:
                    break;
            }
        }

        internal void MenuHandler(Customer customer, int input)
        {
            switch (input)
            {
                case 1:
                    //CreateOrder
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                case 5:
                    break;
                case 6:
                    break;
                case 7:
                    menu.DisplayLoginMenu();
                    break;
                default:
                    break;
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
