using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.SqlServer.Server;
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

                store.LoginHandler(UserIntQuery("Choose menu option:", 0, loginOptions.Length));
            }
        }
        public void DisplayMainMenu(Customer customer)
        {
            bool run = true;
            while (run)
            {
                Console.WriteLine($"Logged in as customer: {customer.FirstName} {customer.LastName}\n");

                Array.ForEach(menuOptions, Console.WriteLine);

                run = store.MenuHandler(customer, UserIntQuery("Choose menu option:", 0, menuOptions.Length));
            }
        }

        internal string[] UserLoginQuery()
        {
            string[] loginCredentials = new string[2];

            //Email
            Console.Write("E-mail:");
            loginCredentials[0] = Console.ReadLine().ToLower();

            //Password
            Console.Write("Password:");
            loginCredentials[1] = Console.ReadLine();

            return loginCredentials;
        }

        public void DisplayOrderMenu()
        {

        }

        public void ListCustomers()
        {

        }

        public void PrintList<T>(List<T> list, double price )
        {
            if (list.GetType() == typeof(List<Product>))
            {
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"[{i + 1}] {list[i]}");
                }
            }
            if(list.GetType() == typeof(List<OrderItems>)) 
            {
                Console.WriteLine("Shopping basket (enter 0 to continue to check-out)");
                for (int i = 0; i < list.Count; i++)
                {
                    Console.WriteLine($"{list[i]}");
                }
                Console.WriteLine($"Total cost: {price}SEK");
            }
        }
        //public void PrintList(List<OrderItems> list)
        //{
        //    for (int i = 0; i < list.Count; i++)
        //    {
        //        Console.WriteLine($"{list[i]}");
        //    }
        //}

        public string[] GetCustomerDetails()
        {
            string[] newCustomerDetails = new string[6];
            Console.Write("Enter first name: ");
            newCustomerDetails[0] = Console.ReadLine();
            Console.Write("Enter last name: ");
            newCustomerDetails[1] = Console.ReadLine();
            Console.Write("Enter address: ");
            newCustomerDetails[2] = Console.ReadLine();
            Console.Write("Enter phone nr.: ");
            newCustomerDetails[3] = Console.ReadLine();
            Console.Write("Enter email: ");
            newCustomerDetails[4] = Console.ReadLine();
            Console.Write("Enter password: ");
            newCustomerDetails[5] = Console.ReadLine();

            return newCustomerDetails;
        }

        public int UserIntQuery(string question, int minValue, int maxValue)
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
