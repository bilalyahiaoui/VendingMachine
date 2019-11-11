using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.FoodClass
{
    public class Gum : Food
    {
        public Gum(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
        }

        public override string FunnyMessage()
        {
            return "Chew, Chew, Yum!";
        }
    }
}
