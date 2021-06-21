using System;

namespace HungryNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            Buffet b = new Buffet();
            Ninja Abeer = new Ninja();
            while(!Abeer.IsFull){
                Abeer.Eat(b.Serve());
            }
            Abeer.Eat(b.Serve());
    
        }
    }
}
