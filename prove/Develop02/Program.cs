using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        // Main loop for journal application
        while (running)
        {
            Console.WriteLine("Choose an option: 1. Add Entry, 2. Display Entries, 3. Save Journal, 4. Load Journal, 5. Search Entries, 6. Exit");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.WriteLine("Enter your journal entry: ");
                    string text = Console.ReadLine();
                    journal.AddEntry(text);
                    break;
                case "2":
                    journal.DisplayEntries();
                    break;
                case "3":
                    journal.SaveJournal("journal.txt");
                    break;
                case "4":
                    journal.LoadJournal("journal.txt");
                    break;
                case "5":
                    Console.WriteLine("Enter a keyword to search for: ");
                    string keyword = Console.ReadLine();
                    journal.SearchEntries(keyword);
                    break;
                case "6":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    }
}
