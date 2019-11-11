using System;
using System.Text;
using Capstone.VendingMachine;


namespace Capstone.VendingMachine
{
    public class Program
    {
        static void Main(string[] args)
        {
            VendingMachine Blue = new VendingMachine();
            Blue.InitialGreeting();
            Blue.MainMenu();
            Console.ReadLine();


        }
    }
}
