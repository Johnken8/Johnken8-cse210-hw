public class Journal
{
    private List<Entry> Entries = new List<Entry>();
    private List<string> Prompts = new List<string> 
    { 
        "What did you accomplish today?", 
        "What are you grateful for?", 
        "What challenges did you face?" 
    };

    public void AddEntry(string text)
    {
        string randomPrompt = GetRandomPrompt();
        Entry newEntry = new Entry(randomPrompt, text);
        Entries.Add(newEntry);
    }

    public void DisplayEntries()
    {
        foreach (var entry in Entries)
        {
            Console.WriteLine(entry.DisplayEntry());
        }
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return Prompts[rand.Next(Prompts.Count)];
    }

    public void SaveJournal(string filename)
    {
        using (StreamWriter sw = new StreamWriter(filename))
        {
            foreach (var entry in Entries)
            {
                sw.WriteLine($"{entry.EntryDate},{entry.Prompt},{entry.Text}");
            }
        }
        Console.WriteLine("Journal saved successfully.");
    }

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
                Entries.Add(new Entry(prompt, text) { EntryDate = date });
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        else
        {
            Console.WriteLine("No journal file found.");
        }
    }
}
