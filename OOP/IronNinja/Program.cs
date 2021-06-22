using System;

namespace IronNinja
{
    class Program
    {
        static void Main(string[] args)
        {
            SweetTooth sweet = new SweetTooth();
            SpiceHound spice = new SpiceHound();
            Buffet b = new Buffet();

            while(!sweet.IsFull){
                sweet.Consume(b.Serve());

            }
            while(!spice.IsFull){
                spice.Consume(b.Serve());

            }
            if(sweet.ConsumptionHistory.Count < spice.ConsumptionHistory.Count){
                Console.WriteLine($"The Spice is won because ate {spice.ConsumptionHistory.Count} items");

            }
            else{
                Console.WriteLine($"The Sweet is won because ate {spice.ConsumptionHistory.Count} items");
            }
          
        }
    }
}
