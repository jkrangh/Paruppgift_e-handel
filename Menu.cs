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
        private string[] adminOptions;

        public Menu(Store store, string[] loginOptions, string[] menuOptions, string[] adminOptions)
        {
            this.store = store;
            this.loginOptions = loginOptions;
            this.menuOptions = menuOptions;
            this.adminOptions = adminOptions;
        }
        public void DisplayLoginMenu()
        {
            while (true)
            {
                PrintHeader();
                Array.ForEach(loginOptions, Console.WriteLine);

                store.LoginHandler(UserIntQuery("Choose menu option:", 0, loginOptions.Length));
                Console.Clear();
            }
        }
        public void DisplayMainMenu(Customer customer)
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine($"Logged in as customer: {customer.FirstName} {customer.LastName}\n");

                Array.ForEach(menuOptions, Console.WriteLine);

                run = store.MenuHandler(customer, UserIntQuery("Choose menu option:", 0, menuOptions.Length));
            }
        }
        public void DisplayAdminMenu(Admin admin)
        {
            bool run = true;
            while (run)
            {
                Console.Clear();
                PrintHeader();
                Console.WriteLine($"Logged in as admin: {admin.FirstName} {admin.LastName}\n");

                Array.ForEach(adminOptions, Console.WriteLine);

                run = store.AdminMenuHandler(admin, UserIntQuery("Choose menu option:", 0, adminOptions.Length));
            }
        }

        internal string[] UserLoginQuery()
        {
            string[] loginCredentials = new string[2];

            //Email
            Console.Write("E-mail: ");
            loginCredentials[0] = Console.ReadLine().ToLower();

            //Password
            Console.Write("Password: ");
            loginCredentials[1] = Console.ReadLine();

            return loginCredentials;
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
        public void GetProductDetails()
        {                       
            
            Console.Write("Enter description: ");
            string description = Console.ReadLine();
            Console.Write("Enter Brand: ");
            string brand = Console.ReadLine();
            
            for (int i = 1; i <= Enum.GetValues(typeof(Category)).Length; i++)
            {
                Console.WriteLine($"[{i}] {(Category)i}");
            }
            //foreach (string name in Enum.GetNames(typeof(Category)))
            //{
            //    Console.WriteLine($"[{i}] {name}");
            //    i++;
            //}
            Category category = (Category)UserIntQuery("Enter categorynumber: ", 1, Enum.GetValues(typeof(Category)).Length);
            double price = UserDoubleQuery("Enter price: ", 0, double.MaxValue);
            
            store.AddProduct(description, brand, category, price);
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
        public double UserDoubleQuery(string question, double minValue, double maxValue)
        {
            double value = 0;
            bool validInput = false;

            while (!validInput)
            {
                Console.Write(question);
                validInput = double.TryParse(Console.ReadLine(), out value);

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
            Console.WriteLine("==== Stekarjannes Fisk och Grönt ====");
            Console.WriteLine();
        }

        public void PrintLoginFail()
        {
            Console.WriteLine("Wrong user credentials entered.");
        }

        public void EntryFail()
        {
            Console.WriteLine("Invalid entry.");
            Console.ReadKey();
        }
    }
}
