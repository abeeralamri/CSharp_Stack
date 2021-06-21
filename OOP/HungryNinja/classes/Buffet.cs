using System;
using System.Collections.Generic;

namespace HungryNinja
{
    public class Buffet
    {
        public List<Food> Menu;
     
    //constructor
    public Buffet()
    {
        Menu = new List<Food>()
        {
            new Food("Banana",  83, false, true),
            new Food("Chickpea", 164, false, false),
            new Food("Egg", 72, false, false),
            new Food("Strawberry", 33, false, true),
            new Food("Peanut butter", 100, false, true),
            new Food("Cashew", 276, false, false),
            new Food("Rice", 260, false, false),
        };
        
    }
     
    public Food Serve()
    {
        Random random = new Random();
        return Menu[random.Next(Menu.Count)];
    }
}

}