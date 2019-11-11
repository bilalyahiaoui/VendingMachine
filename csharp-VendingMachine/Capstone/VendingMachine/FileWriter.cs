using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.VendingMachine
{
    public class FileWriter
    {
        public static string writeFileDirectory = Environment.CurrentDirectory; 
        public static string fileName = "Daily_Sales_Log.txt";
        public string writefileFullPath = Path.Combine(writeFileDirectory, fileName);

        public void WriteTransactionToLog(string message, decimal money, decimal CurrentCashLoad)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(writefileFullPath, true))
                {
                    sw.Write(DateTime.UtcNow + message + $": {money:C2} {CurrentCashLoad:C2} \n");
                }

            }
            catch (Exception e) {

            }
        }
    }
 }

