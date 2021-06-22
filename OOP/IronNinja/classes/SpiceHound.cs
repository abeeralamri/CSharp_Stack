using System;

namespace IronNinja
{
    class SpiceHound : Ninja
{
    
     public override bool IsFull
        {
            get
            {
        if(calorieIntake > 1500){
            return true;
        }
            return false;
        }
        
        }
    

  
    public override void Consume(IConsumable item){
        if(IsFull){
            Console.WriteLine("The SpiceHound is full and cannot eat anymore");
        }
        else{
            if(item.IsSweet){
                calorieIntake += item.Calories + 10;


            }
            else{
                calorieIntake += item.Calories;
            }
            ConsumptionHistory.Add(item);
            item.GetInfo();
        }
          item.GetInfo();


}


}
}