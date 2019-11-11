using System;
using System.Collections.Generic;
using System.Text;
using Capstone.FoodClass;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Threading.Tasks;

namespace CapstoneTests.FoodClassTests
{
    [TestClass]
    public class FoodClassTests
    {
        

        [TestMethod]
        public void Gum_Class_Returns_Chew()
        {
                Gum testGum = new Gum(null,2);
                Assert.AreEqual("Chew, Chew, Yum!", testGum.FunnyMessage());
        }

        [TestMethod]
        public void Drink_Class_Returns_Glug()
        {
            Drink testDrink = new Drink(null,2);
            Assert.AreEqual("Glug, Glug, Yum!", testDrink.FunnyMessage());
        }

        [TestMethod]
        public void Candy_Class_Returns_Munch()
        {
             Candy testCandy = new Candy(null,0);
             Assert.AreEqual("Munch, Munch, Yum!", testCandy.FunnyMessage());
        }

        [TestMethod]
        public void Chip_Class_Returns_Crunch()
        {
            Chip testChip = new Chip(null,2);
            Assert.AreEqual("Crunch, Crunch, Yum!", testChip.FunnyMessage());
        }

        [DataTestMethod]
        [DataRow("candy", "1.50")]
        [DataRow("ninjatestparty", "1.50")]
        public void Food_Classes_Properly_Implement_Constructor(string name, string price)
        {
            decimal newPrice = decimal.Parse(price);

            Candy testCandy2 = new Candy(name, newPrice);
            Assert.IsTrue(testCandy2.Name == name && testCandy2.Price == newPrice);

            Chip testChip2 = new Chip(name, newPrice);
            Assert.IsTrue(testChip2.Name == name && testChip2.Price == newPrice);

            Drink drinky = new Drink(name, newPrice);
            Assert.IsTrue(drinky.Name == name && drinky.Price == newPrice);

            Gum gummy = new Gum(name, newPrice);
            Assert.IsTrue(gummy.Name == name && gummy.Price == newPrice);

        }



    }
}
