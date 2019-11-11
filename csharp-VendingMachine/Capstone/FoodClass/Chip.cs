using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.FoodClass
{
    public class Chip : Food
    {
        public Chip(string name, decimal price)
        {
            Name = name;
            Price = price;
            Quantity = 5;
        }

        public override string FunnyMessage()
        {
            return "Crunch, Crunch, Yum!";
        }
    }
}
