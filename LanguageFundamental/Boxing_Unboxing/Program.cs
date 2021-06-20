using System;
using System.Collections.Generic;

namespace Boxing_Unboxing
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Object> obj = new List<Object>();
            obj.Add(7);
            obj.Add(28);
            obj.Add(-1);
            obj.Add(true);
            obj.Add("chair");
            int sum = 0;
            for(int i = 0; i<obj.Count; i++){
                Console.WriteLine(obj[i]);
                if(obj[i] is int){
                    sum = sum + (int)obj[i] ;
                    
                }
                
            }
            
            Console.WriteLine("Sum:" + sum);

        }
    }
}
