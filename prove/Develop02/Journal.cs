using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class Journal
{
    private List<Entry> _entries = new List<Entry>(); // Changed to underscore convention
    private List<string> _prompts = new List<string> // Changed to underscore convention
    { 
        "What did you accomplish today?", 
        "What are you grateful for?", 
        "What challenges did you face?" 
    };

    // Method to add a new entry to the journal
    public void AddEntry(string text)
    {
        string randomPrompt = GetRandomPrompt();
        Entry newEntry = new Entry(randomPrompt, text);
        _entries.Add(newEntry);
    }

    // Method to display all journal entries
    public void DisplayEntries()
    {
        foreach (var entry in _entries)
        {
            Console.WriteLine(entry.DisplayEntry());
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
                sw.WriteLine($"{entry.EntryDate},{entry.Prompt},{entry.Text}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

    // Method to load journal entries from a file
    public void LoadJournal(string filename)
    {
        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                var parts = line.Split(',');
                DateTime date = DateTime.Parse(parts[0]);
                string prompt = parts[1];
                string text = parts[2];
                _entries.Add(new Entry(prompt, text) { EntryDate = date });
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
                                              e.Prompt.Contains(keyword, StringComparison.OrdinalIgnoreCase)).ToList();
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
}
