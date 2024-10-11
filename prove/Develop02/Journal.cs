using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>(); // List of entries
    private List<string> _prompts = new List<string>
    {
        "What did you accomplish today?",
        "What are you grateful for?",
        "What challenges did you face?",
        "What is one thing you learned today?",
        "What are your goals for tomorrow?"
    };

    // Method to add a new entry to the journal with optional tags
    public void AddEntry(string text, string tags = "")
    {
        string randomPrompt = GetRandomPrompt();
        Entry newEntry = new Entry(randomPrompt, text, tags);
        _entries.Add(newEntry);
    }

    // Method to display all journal entries
    public void DisplayEntries()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("No entries to display.");
        }
        else
        {
            foreach (var entry in _entries)
            {
                Console.WriteLine(entry.DisplayEntry());
            }
        }
    }

    // Method to get a random prompt
    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    // Method to save journal entries to a file
    public void SaveJournal(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in _entries)
            {
                sw.WriteLine($"{entry.EntryDate},{entry.Prompt},{entry.Text},{entry.Tags}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    // Method to load journal entries from a file
    public void LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            _entries.Clear(); // Clear current entries before loading new ones
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                var parts = line.Split(',');
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string text = parts[2];
                string tags = parts.Length > 3 ? parts[3] : ""; // Handle cases without tags
                _entries.Add(new Entry(prompt, text, tags) { EntryDate = date });
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("No journal file found.");
        }
    }

    // Method to search entries by a keyword
    public void SearchEntries(string keyword)
    {
        var foundEntries = _entries.Where(e => e.Text.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                               e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                                               e.Tags.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
        if (foundEntries.Count == 0)
        {
            Console.WriteLine("No entries found matching the keyword.");
        }
        else
        {
            foreach (var entry in foundEntries)
            {
                Console.WriteLine(entry.DisplayEntry());
            }
        }
    }

    // Method to edit an existing entry
    public void EditEntry(string date)
    {
        var entry = _entries.FirstOrDefault(e => e.EntryDate.ToShortDateString() == date);
        if (entry != null)
        {
            Console.WriteLine("Editing Entry: ");
            Console.WriteLine(entry.DisplayEntry());
            Console.WriteLine("Enter the new text for this entry: ");
            string newText = Console.ReadLine();
            entry.Text = newText;
            Console.WriteLine("Entry updated successfully.");
        }
        else
        {
            Console.WriteLine("No entry found for the given date.");
        }
    }

    // Method to delete an entry
    public void DeleteEntry(string date)
    {
        var entry = _entries.FirstOrDefault(e => e.EntryDate.ToShortDateString() == date);
        if (entry != null)
        {
            _entries.Remove(entry);
            Console.WriteLine("Entry deleted successfully.");
        }
        else
        {
            Console.WriteLine("No entry found for the given date.");
        }
    }
}
