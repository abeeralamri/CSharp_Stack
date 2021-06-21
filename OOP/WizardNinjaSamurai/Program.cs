using System;

namespace WizardNinjaSamurai
{
    class Program
    {
        static void Main(string[] args)
        {
            Wizard Abeer = new Wizard("Abeer");
            Ninja A = new Ninja("A");
            Samurai B = new Samurai("B");
            Abeer.Attack(A);
            Abeer.Heal(A);

            A.Attack(Abeer);
            A.Steal(Abeer);

            Abeer.Attack(B);
            Abeer.Heal(B);

            B.Attack(Abeer);
            B.Meditate();
            
        }
    }
}
