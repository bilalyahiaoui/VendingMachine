using Capstone.FoodClass;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.VendingMachine
{
    public class FileReader 
    {
        public static Dictionary<string, Food> Contents = new Dictionary<string, Food>();

        public Dictionary<string, Food> FillMachine()
        {
            string filePath = Directory.GetCurrentDirectory();
            string fileName = "textfile1.txt";
            string fullFileName = Path.Combine(filePath, fileName);

            try
            {
                using (StreamReader sr = new StreamReader(fullFileName))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] wordArray = line.Split("|");

                        switch (wordArray[3].ToLower())
                        {
                            case "chip":
                                Contents.Add(wordArray[0], new Chip(wordArray[1], decimal.Parse(wordArray[2])));
                                break;
                            case "drink":
                                Contents.Add(wordArray[0], new Drink(wordArray[1], decimal.Parse(wordArray[2])));
                                break;
                            case "gum":
                                Contents.Add(wordArray[0], new Gum(wordArray[1], decimal.Parse(wordArray[2])));
                                break;
                            case "candy":
                                Contents.Add(wordArray[0], new Candy(wordArray[1], decimal.Parse(wordArray[2])));
                                break;
                            default:
                                break;
                        }
                    }
                }
            }
            catch (Exception e) { }
           
            return Contents;
        }
    }
}
