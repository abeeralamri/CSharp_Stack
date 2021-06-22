using System;

namespace IronNinja
{
    class Drink : IConsumable
{
    public string Name {get;set;}
    public int Calories {get;set;}
    public bool IsSpicy {get;set;}
    public bool IsSweet {get;set;}
    
    public Drink(string name, int calories, bool isSpicy, bool isSweet){
        Name = name;
        Calories = calories;
        IsSpicy = isSpicy;
        IsSpicy = isSweet;
    }
    public string GetInfo(){
        return $"{Name} (Drink).  Calories: {Calories}.  Spicy?: {IsSpicy}, Sweet?: {IsSweet}";

    }    

}  
}