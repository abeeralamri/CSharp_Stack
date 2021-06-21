using System;

namespace HungryNinja
{
    public class Food
    {
        public string Name;
        public int Calories;
        public bool IsSpicy;
        public bool IsSweet;
        public Food (string name, int cal, bool isSpicy, bool isSweet){
            Name = name;
            Calories = cal;
            IsSpicy = isSpicy;
            IsSweet = isSweet;
        
        }
    }
}