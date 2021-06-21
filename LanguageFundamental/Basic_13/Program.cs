using System;
using System.Collections.Generic;
namespace Basic_13
{
    public class Program
    {
        public static void PrintNumbers()
        {
             for(int i = 1; i <= 255; i++){
                Console.WriteLine(i);
            }
        }

        public static void PrintOdds()
        {
            for(int i = 1; i <= 255; i++){
                if(!(i%2==0)){
                Console.WriteLine(i);
            }}
            
        }
        public static void PrintSum()
        {
            int sum =0;
             for(int i = 0; i <= 255; i++){
                sum = sum+i;
                Console.WriteLine("number: "+ i + " Sum:" + sum );
            }
            
        }
        public static void LoopArray(int[] numbers)
        {
            // Write a function that would iterate through each item of the given integer array and 
            // print each value to the console. 
            foreach(int num in numbers){
                Console.WriteLine(num);
            }
        }
        public static int FindMax(int[] numbers)
        {
          
            int max = numbers[0];
            for(int num = 0; num<numbers.Length; num++){
                if(max < numbers[num]){
                    max = numbers[num];
                }
                           }
            return max;
        }
        public static void GetAverage(int[] numbers)
        {
            int avg = 0;
            int sum = 0;
            for(int num = 0; num<numbers.Length; num++){
                sum = sum + numbers[num];
                
            }
            avg = sum / numbers.Length;
            Console.WriteLine("Average: "+avg);
        }
        public static int[] OddArray()
        {
           int [] arr = new int [130];
           int idx = 0;
           for(int i = 0; i <= 255; i++){
                if(!(i%2==0)){
                arr[idx] = i;
                idx++;
            }}
            return arr;
        }
        public static int GreaterThanY(int[] numbers, int y)
        {

             int max = numbers[0];
             int count = 0;
            for(int num = 0; num<numbers.Length; num++){
                if(y < numbers[num]){
                    count++;
                }
            }
            return count;
        }
        public static void SquareArrayValues(int[] numbers)
        {
             
             for(int i = 0; i < numbers.Length; i++){
                numbers[i] *= numbers[i];
                
            }
            Console.WriteLine(string.Join(",", numbers));
        }
        public static void EliminateNegatives(int[] numbers)
            {
                for(int i = 0; i<numbers.Length; i++){
                    if(numbers[i] < 0){
                        numbers[i] = 0;
                    }
                }
                Console.WriteLine(numbers);
            
            }
        public static void MinMaxAverage(int[] numbers)
            {
                int max = numbers[0];
                int min = numbers[0];
                int avg = 0;
                int sum = 0;
                for(int num = 0; num<numbers.Length; num++){
                    sum += numbers[num];
                  if(max < numbers[num]){
                     max = numbers[num];
                    }
                if(numbers[num] < min){
                    min = numbers[num];
                }
                }
                avg = sum / numbers.Length;
                Console.WriteLine("Min: "+min + " Max: "+max + " Average: "+avg);
            }
        public static void ShiftValues(int[] numbers)
        {
                for(int i = 0; i < numbers.Length-1 ;i++){
                    numbers[i] = numbers[i+1];
                    ;
                }
                numbers[numbers.Length-1] = 0;
                Console.WriteLine(string.Join(",", numbers));
        }

        public static object[] NumToString(int[] numbers)
        {
                object [] nums = new object[numbers.Length];
                for(int i = 0; i<numbers.Length;i++){
                    if(numbers[i] < 0){
                        nums[i] = "Dojo";
                    }
                    else {
                        nums[i] = numbers[i];
                    }

                }
                
                return nums;
        }


        public static void Main(string[] args)
        {   int [] nums = {-2, -10, 3, 11, 12, 15};

            PrintNumbers();
            PrintOdds();
            PrintSum();
            LoopArray(nums);
            Console.WriteLine("Max: "+FindMax(nums));
            GetAverage(nums);
            Console.WriteLine(OddArray());
            Console.WriteLine(GreaterThanY(nums, 3));
            SquareArrayValues(nums);
            EliminateNegatives(nums);
            MinMaxAverage(nums);
            ShiftValues(nums);
            Console.WriteLine(NumToString(nums));
        }
    }
}
