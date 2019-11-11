using Capstone.VendingMachine;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CapstoneTests.FileReader
{
    [TestClass]
    public class FileWriterTest
    {
        [TestMethod]
        public void FileWriterTest1()
        {
                 string writeFileDirectory = Environment.CurrentDirectory;
                 string fileName = "Daily_Sales_Log.txt";
                 string writefileFullPath = Path.Combine(writeFileDirectory, fileName);
                 File.Delete(writefileFullPath);
                 FileWriter fw = new FileWriter();
                 fw.WriteTransactionToLog("bilal", 0.5m, 0.5m);
                 Assert.IsTrue(File.Exists(writefileFullPath));
        }
    }

}
