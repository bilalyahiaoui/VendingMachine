using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.FoodClass
{
    public abstract class Food
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }

        public abstract string FunnyMessage();
    }
}
