using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class Menu
    {
        private Store store;
        private string[] loginOptions;
        private string[] menuOptions;
        public Menu(Store store, string[] loginOptions, string[] menuOptions)
        {
            this.store = store;
            this.loginOptions = loginOptions;
            this.menuOptions = menuOptions;
        }
        public void DisplayLoginMenu()
        {
            while (true)
            {
                Array.ForEach(loginOptions, Console.WriteLine);

                store.LoginHandler(GetIntFromUser("Choose menu option:", 0, loginOptions.Length));
            }
        }
        public void DisplayMainMenu(Customer customer)
        {
            while (true)
            {
                Console.WriteLine($"Logged in as customer: {customer.FirstName} {customer.LastName}\n");

                Array.ForEach(menuOptions, Console.WriteLine);

                store.MenuHandler(customer, GetIntFromUser("Choose menu option:", 0, menuOptions.Length));
            }
        }

        internal string[] CustomerLoginQuery()
        {
            string[] customerCredentials = new string[2];

            //Email
            Console.Write("E-mail:");
            customerCredentials[0] = Console.ReadLine().ToLower();

            //Password
            Console.Write("Password:");
            customerCredentials[1] = Console.ReadLine();

            return customerCredentials;
        }

        public void DisplayOrderMenu()
        {

        }

        public void ListCustomers()
        {

        }

        public void ListProducts()
        {

        }

        public void ListOrders()
        {

        }

        public int GetIntFromUser(string question, int minValue, int maxValue)
        {
            int value = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(question);
                validInput = int.TryParse(Console.ReadLine(), out value);

                if (value < minValue || value > maxValue || !validInput)
                {
                    validInput = false;
                    Console.WriteLine("\n Invalid entry. Please try again.\n");
                }
            }

            return value;
        }

        public void PrintHeader()
        {
            Console.WriteLine("==== E-Handel ====");
        }

        public void PrintLoginFail()
        {
            Console.WriteLine("Wrong user credentials entered.");
        }
    }
}
