using System;

namespace Human
{
    class Program
    {
        static void Main(string[] args)
        {
            Human Abeer = new Human("Abeer");
            Human Amal = new Human("Amal", 5,3,2,200);
            Console.WriteLine(Abeer.Health);
            Console.WriteLine(Abeer.Attack(Amal));

        }
    }
}
