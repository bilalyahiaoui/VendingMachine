using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Capstone.FoodClass;

namespace Capstone.VendingMachine
{
    public class CashDrawer
    {
        public decimal CurrentCashLoad { get; private set; }

        public Dictionary<string, Food> Contents = new FileReader().FillMachine();

        FileWriter fw = new FileWriter();

        public void LoadMoney()
        {
            Console.WriteLine("You can load money using digit characters onto the machine in whole dollar amounts." +
                "\nNo change Please. Enter '0' to exit immediately\n");
            try
            {
                int addAsDecimal = int.Parse(Console.ReadLine());
                if (addAsDecimal >= 0)
                {
                    CurrentCashLoad += addAsDecimal;
                    fw.WriteTransactionToLog(" FEED MONEY ", addAsDecimal, CurrentCashLoad);
                    Console.Clear();
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nBlue is no bank, customer! She can't lend money.\n");
                    LoadMoney();
                }
            }
            catch (Exception e)
            {
                Console.Clear();
                Console.WriteLine("The input was not valid. Please only use whole digits, like '4' or '100'.\n" +
                    "Press 'Enter'\n");
                LoadMoney();
            }
        }

        public void PurchaseItem()
        {
            Console.WriteLine("Please choose an Item using the slot key.");

            string userInput = Console.ReadLine().ToUpper();

            foreach (KeyValuePair<string, Food> keyValuePair in Contents)
            {
                if (Contents.ContainsKey(userInput))
                {
                    if (keyValuePair.Key == userInput)
                    {
                        if (CurrentCashLoad < keyValuePair.Value.Price)
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou must load more money to complete this transaction.\n");
                            return;
                        }
                        else if (keyValuePair.Value.Quantity > 0)
                        {
                            decimal change = CurrentCashLoad - keyValuePair.Value.Price;
                            string message = $" {keyValuePair.Value.Name} {keyValuePair.Key} ";

                            fw.WriteTransactionToLog(message, change, CurrentCashLoad);

                            CurrentCashLoad = CurrentCashLoad - keyValuePair.Value.Price;

                            keyValuePair.Value.Quantity = keyValuePair.Value.Quantity - 1;

                            Console.Clear();
                            Console.WriteLine(keyValuePair.Value.FunnyMessage() + "\n");
                            return;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Our apologies! Blue is SOLD OUT of your selection.\n");
                            return;
                        }
                    }
                }
            }Console.Clear();
             Console.WriteLine("The selection you have chosen does not exist.\n");
             return;
        }

        public void FinishTransaction()
        {
            Console.Clear();
            decimal change = CurrentCashLoad;// % 1M;
            int dollars = 0;
            int quarters = 0;
            int dimes = 0;
            int nickels = 0;
            int pennies = 0;
 
            while (change > 0)
            {
                if (change >= 1)
                {
                    dollars++;
                    change = change - 1M;
                }
                else if (change >= 0.25M)
                {
                    quarters++;
                    change = change - 0.25M;
                }
                else if (change >= 0.10M)
                {
                    dimes++;
                    change = change - 0.10M;
                }
                else if (change >= 0.05M)
                {
                    nickels++;
                    change = change - 0.05M;
                }
                else if (change >= 0.01M)
                {
                    pennies++;
                    change = change - 0.01M;
                }

            }
            Console.WriteLine($"Your change is {CurrentCashLoad:C2}" +
                              $"\nThat's {dollars} Dollar(s), {quarters} quarter(s), " +
                              $"{dimes} dime(s), {nickels} nickel(s) and {pennies} pennies.\n");
            fw.WriteTransactionToLog(" GIVE CHANGE ", CurrentCashLoad, change);
     
            CurrentCashLoad = 0;
        }
    }
}
