using Capstone.FoodClass;
using Capstone.VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;


namespace CapstoneTests.FileReader
{
    [TestClass]
    public class ReaderTestClasses
    {
            
        [TestMethod]
        public void FileReader_Creates_Dictionary()
        {
           
            Dictionary<string, Food> Contents = new Dictionary<string, Food>();
            Capstone.VendingMachine.FileReader sr = new Capstone.VendingMachine.FileReader();
            sr.FillMachine();


            foreach (KeyValuePair<string, Food> keyValuePair in Contents)
            {
                if (Contents.ContainsKey(keyValuePair.Key))
                { Assert.AreEqual(Contents[keyValuePair.Key], keyValuePair.Value); }
            }
        }
    }
}
