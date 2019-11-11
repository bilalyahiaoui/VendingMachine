using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.FoodClass
{
    public class Candy : Food
    {

        public Candy(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
        }

        public override string FunnyMessage()
        {
            return "Munch, Munch, Yum!";
        }
    }
}
