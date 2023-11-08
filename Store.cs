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
            while (true)
            {
                switch (input)
                {
                    case 1:
                        //Login
                        //Menuhandler()
                        break;
                    case 2:
                        break;
                    case 3:
                        return;
                    default:
                        break;
                }
            }
        }

        internal void MenuHandler(int input)
        {
            while (true)
            {
                switch (input)
                {
                    case 1:
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
                        return;
                    default:
                        break;
                }
            }
        }
    }
}
