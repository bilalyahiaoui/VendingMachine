using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.FoodClass;
using Capstone.VendingMachine;

namespace Capstone.VendingMachine
{
    public class VendingMachine
    {

        public Dictionary<string, Food> Contents = new FileReader().FillMachine();

        public CashDrawer MoneyChanger = new CashDrawer();

        public void DisplayContents()
        {
            Console.Clear();
            foreach (KeyValuePair<string, Food> keyValuePair in Contents)
            {
                string slot = keyValuePair.Key;

                Console.WriteLine($"{slot} | {keyValuePair.Value.Name} | {keyValuePair.Value.Price} | {keyValuePair.Value.Quantity}");
            }
            
        }

        public void PurchaseMenu()
        {
            //Console.Clear();
            Console.WriteLine("This is Blue's purchase menu.\n What would you like to do?\n" +
                "\n1) Load Money\n2) Purchase Item\n3) Finish Transaction\n");

            Console.WriteLine($"Current Cash Load: {MoneyChanger.CurrentCashLoad:C2}");
            string purchaseMenuInput = Console.ReadLine(); Console.WriteLine();

            switch (purchaseMenuInput)
            {
                case "1": Console.Clear();
                          MoneyChanger.LoadMoney();
                          PurchaseMenu();
                          break;
                case "2": Console.Clear();
                          DisplayContents();
                          MoneyChanger.PurchaseItem();
                          PurchaseMenu();
                          break;
                case "3": Console.Clear();
                          MoneyChanger.FinishTransaction();
                          MainMenu();
                          break;
                case "4": Console.WriteLine("Sorry, that's not an option here, either.");
                          Console.ReadLine();
                          PurchaseMenu(); break;
                default: Console.Clear();
                         Console.WriteLine("Please continue to use 1, 2, or 3 for your input.");
                         PurchaseMenu(); break;       
            }
        }

        public void InitialGreeting()
        {
            Console.WriteLine("Hi! Welcome to our vending machine! We call her Blue." +
                "\nWhat can Blue do for you?\n");
        }

        public void MainMenu()
        {
            Console.WriteLine("Main Menu\n1) Display Blue's Wares" +
                              "\n2) Purchase\n3) Say Goodbye! \n9) Greet Blue\n");
            string menuInput = Console.ReadLine();

            Console.WriteLine();

            switch (menuInput)
            {
                case "1": DisplayContents();
                          Console.ReadLine();
                          MainMenu();
                          break;
                case "2": Console.Clear();
                          PurchaseMenu();
                          break;
                case "3": Console.Clear();
                          Console.WriteLine("Blue says 'Goodbye! Have a nice day!'");
                          Console.ReadLine();
                          System.Environment.Exit(1);
                          break;
                case "4": Console.Clear();
                          Console.WriteLine("Woah, this feature is still in development. Please return later.");
                          MainMenu();
                          break;
                case "9": Console.Clear();
                          Console.WriteLine("\nBlue says Hi! <3\n");
                          MainMenu();
                          break;
                default: Console.Clear();
                         Console.WriteLine("Please use 1, 2, 3, or 9 for your input\n");
                         MainMenu();
                         break;
            }

        }
    }
}
