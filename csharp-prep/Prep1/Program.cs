using System;

class Program
{
    static void Main(string[] args)
    {
        // Function to get a valid input from the user
        string GetValidInput(string prompt)
        {
            string input;
            do
            {
                Console.Write(prompt);
                input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Input cannot be empty. Please try again.");
                }
            } while (string.IsNullOrEmpty(input));

            return input;
        }

        // Prompt the user for their first name
        string firstName = GetValidInput("What is your first name? ");

        // Prompt the user for their last name
        string lastName = GetValidInput("What is your last name? ");

        // Display the formatted name
        Console.WriteLine($"Your name is {lastName}, {firstName} {lastName}.");
    }
}
