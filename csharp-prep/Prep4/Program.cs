using System;
using System.Collections.Generic;

namespace Prep4
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("Enter a list of numbers, type 0 when finished.");
            
            int userInput;
            do
            {
                Console.Write("Enter number: ");
                userInput = int.Parse(Console.ReadLine());
                
                if (userInput != 0)
                {
                    numbers.Add(userInput);
                }
                
            } while (userInput != 0);

            // Proceed with core requirements
            if (numbers.Count > 0)
            {
                // Step 3: Compute and Display Results
                int sum = CalculateSum(numbers);
                double average = CalculateAverage(numbers);
                int max = FindMax(numbers);

                Console.WriteLine($"The sum is: {sum}");
                Console.WriteLine($"The average is: {average}");
                Console.WriteLine($"The largest number is: {max}");

                // Optional: Stretch Challenges
                int smallestPositive = FindSmallestPositive(numbers);
                numbers.Sort();

                Console.WriteLine($"The smallest positive number is: {smallestPositive}");
                Console.WriteLine("The sorted list is:");
                foreach (int number in numbers)
                {
                    Console.WriteLine(number);
                }
            }
            else
            {
                Console.WriteLine("No numbers were entered.");
            }
        }

        // Step 3: Core Requirement Methods
        static int CalculateSum(List<int> numbers)
        {
            int sum = 0;
            foreach (int number in numbers)
            {
                sum += number;
            }
            return sum;
        }

        static double CalculateAverage(List<int> numbers)
        {
            int sum = CalculateSum(numbers);
            return (double)sum / numbers.Count;
        }

        static int FindMax(List<int> numbers)
        {
            int max = numbers[0];
            foreach (int number in numbers)
            {
                if (number > max)
                {
                    max = number;
                }
            }
            return max;
        }

        // Step 4: Stretch Challenges Methods
        static int FindSmallestPositive(List<int> numbers)
        {
            int smallestPositive = int.MaxValue;
            foreach (int number in numbers)
            {
                if (number > 0 && number < smallestPositive)
                {
                    smallestPositive = number;
                }
            }
            return smallestPositive;
        }
    }
}
