using System;
using System.Collections.Generic;

namespace CollectionPractice
{
    class Program
    {
        static void Main(string[] args)
        {
          //create integer array  0 to 9
          int [] nums = {0,1,2,3,4,5,6,7,8,9};
          foreach(int num in nums){
              Console.WriteLine(num);
          }

          Console.WriteLine();
          //create string array 
          string [] names = new string []{"Tim", "Martin", "Nikki",  "Sara"};
          foreach(string name in names){
            Console.WriteLine(name);
          }
          Console.WriteLine();
          //create boolean array
          bool [] boolean = {true, false,true, false,true, false,true, false,true, false};
          foreach(bool bol in boolean){
              Console.WriteLine(bol);
          } 


          Console.WriteLine();
          //List
            //list of ice cream
            List <string> ice_cream = new List<string>();
            ice_cream.Add("Choclate");
            ice_cream.Add("Vanila");
            ice_cream.Add("Strawberry");
            ice_cream.Add("Coffee");
            ice_cream.Add("Rocky road");
            ice_cream.Add("Pstachio");
            ice_cream.Add("Butter Pecan");
            ice_cream.Add("Peanut butter");
            ice_cream.Add("Cherry");
            ice_cream.Add("Black berry");

            //length of list
            Console.WriteLine("The length of list: "+ice_cream.Count);
            //remove third flavor
            ice_cream.RemoveAt(2);
            //length after remove
            Console.WriteLine("The length of list after remove: "+ice_cream.Count);

            Console.WriteLine();
            //Dictionary
                //create dictionary
                Dictionary<string,string> person = new Dictionary<string, string>();
                for(int i = 0 ; i<names.Length; i++){
                    person.Add(names[i], ice_cream[i]);
                }
                foreach(var entry in person){
                    Console.WriteLine(entry.Key + " - " + entry.Value);
                }

        }

    }
}
