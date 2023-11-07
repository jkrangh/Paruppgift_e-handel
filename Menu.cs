using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paruppgift_e_handel
{
    internal class Menu
    {
        //View
        private Store store;
        
        public Menu(Store store)
        {
            this.store = store;
        }
        public void DisplayLoginMenu()
        {
            Console.WriteLine(store.GetLoginOptions());

            store.LoginHandler(GetIntFromUser("Choose menu option", 0, store.GetLoginOptions().Length));
        }
        public void DisplayMainMenu()
        {
            Console.WriteLine(store.GetMenuOptions());
            
            store.MenuHandler(GetIntFromUser("Choose menu option", 0, store.GetMenuOptions().Length));
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
}
