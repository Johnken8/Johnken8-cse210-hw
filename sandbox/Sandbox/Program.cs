using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // C# Prep 1: Variables, Input, and Output
        DisplayWelcome();
        
        // C# Prep 2: Conditionals
        string userName = PromptUserName();
        int favoriteNumber = PromptUserNumber();
        
        if (favoriteNumber > 0)
        {
            Console.WriteLine($"{userName}, your favorite number is positive.");
        }
        else if (favoriteNumber < 0)
        {
            Console.WriteLine($"{userName}, your favorite number is negative.");
        }
        else
        {
            Console.WriteLine($"{userName}, your favorite number is zero.");
        }
        
        // C# Prep 3: Loops
        Console.WriteLine("Counting up to your favorite number:");
        for (int i = 1; i <= favoriteNumber; i++)
        {
            Console.WriteLine(i);
        }

        // C# Prep 4: Lists
        List<int> numbersList = new List<int>();
        for (int i = 1; i <= favoriteNumber; i++)
        {
            numbersList.Add(i);
        }
        
        Console.WriteLine("Numbers in the list:");
        foreach (int number in numbersList)
        {
            Console.WriteLine(number);
        }
        
        // C# Prep 5: Functions
        int squaredNumber = SquareNumber(favoriteNumber);
        DisplayResult(userName, squaredNumber);
    }

    // C# Prep 5: Functions
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the Program!");
    }
    
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine();
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number;
        if (int.TryParse(input, out number))
        {
            return number;
        }
        else
        {
            Console.WriteLine("Invalid number. Defaulting to 0.");
            return 0;
        }
    }
    
    static int SquareNumber(int number)
    {
        return number * number;
    }
    
    static void DisplayResult(string userName, int squaredNumber)
    {
        Console.WriteLine($"{userName}, the square of your number is {squaredNumber}");
    }
}
