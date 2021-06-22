using System;
using System.Collections.Generic;

namespace IronNinja
{
    class Buffet
    {
        public List<IConsumable> Menu;
        public Buffet()
        {
            Menu = new List<IConsumable>()
            {
            new Food("Banana",  83, false, true),
            new Food("Chickpea", 164, false, false),
            new Food("Egg", 72, false, false),
            new Food("Strawberry", 33, false, true),
            new Food("Peanut butter", 100, false, true),
            new Food("Cashew", 276, false, false),
            new Food("Rice", 260, false, false),
            new Food("Apple Juice", 100, false, true),
            new Food("Orange Juice", 112, false, true),
            new Food("Strawberry Juice", 90, false, true),
            };
        }
        public IConsumable Serve()
        {
            Random rand = new Random();
            return Menu[rand.Next(Menu.Count)];
        }
    }
}