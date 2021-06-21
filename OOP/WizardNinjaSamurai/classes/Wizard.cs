using System;

namespace WizardNinjaSamurai{
class Wizard : Human
{
    public Wizard(string name ) : base(name){
        Intelligence = 25;
        health = 50;

    }
     public override int Attack(Human target){
        int dmg = Intelligence * 5;
        target.health -= dmg;
        Console.WriteLine($"{Name} Attack {target.Name} for {dmg} points");
        return target.Intelligence;

     }
     public int Heal(Human target){
         target.health += (10 * this.Intelligence);
         Console.WriteLine($"{Name} healed {target.Name} with {10 * this.Intelligence} points");
         return target.health;
     }

    
}

}