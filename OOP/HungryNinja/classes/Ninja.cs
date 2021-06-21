using System;
using System.Collections.Generic;


namespace HungryNinja
{
class Ninja
{
    private int calorieIntake;
    public List<Food> FoodHistory;
     
    public Ninja(){
        calorieIntake = 0;
        FoodHistory = new List<Food>{};
    }

    public bool IsFull{
        get{
        if(calorieIntake > 1200){
            return true;
        }
            return false;
        }

    }
     
    public void Eat(Food item)
    {
        if(!this.IsFull){
        FoodHistory.Add(item);
        calorieIntake += item.Calories;
        Console.WriteLine($"Abeer ate:  {item.Name}  is sweet: {item.IsSweet} is spicy {item.IsSpicy}");
    
        }
        else{
            Console.WriteLine("The ninja is full and cannot eat anymore");
        }
    
    }
}

}