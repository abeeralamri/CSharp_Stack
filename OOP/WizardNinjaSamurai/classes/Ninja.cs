using System;

namespace WizardNinjaSamurai{
class Ninja : Human
{
    public Ninja (string name) : base(name){
        Dexterity = 175;
    }
       public override int Attack(Human target){
        int dmg = 0;
        Random random = new Random();
        int num = random.Next(0,100);
        if(num <= 20){
            dmg = 10 + (Dexterity * 5);
        }
        else{
            dmg = Dexterity * 5;
            }
        target.health -= dmg;
        Console.WriteLine($"{Name} Attack {target.Name} for {dmg} points");
        return target.health;

     }
     public int Steal(Human target){
         target.health -= 5;
         this.health += 5;
         Console.WriteLine($"{Name} has stolen 5 health from {target.Name}");
         return target.health;
     }
}

}