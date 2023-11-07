using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class Store
    {
        private Menu menu;
        //Controller
        StoreDbContext storeDb = new StoreDbContext();

        //Menu options:
        private string[] loginOptions = { "1. Customer login", "2. Create new customer", "3. Exit" };
        private string[] menuOptions = { "1. Create order", "2. List available products", "3. List all orders", "4. Edit order",
                                        "5. Delete order", "6. Edit customer details", "7. Customer logout" };
        public Store(Menu menu)
        {
            this.menu = menu;
        }

        internal string[] GetLoginOptions()
        {
            return loginOptions;
        }

        internal string[] GetMenuOptions()
        {
            return menuOptions;
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
