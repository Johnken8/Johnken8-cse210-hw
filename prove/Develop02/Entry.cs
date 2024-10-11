using System;

public class Entry
{
    public DateTime EntryDate { get; set; }
    public string Prompt { get; set; }
    public string Text { get; set; }
    public string Tags { get; set; }

    public Entry(string prompt, string text, string tags = "")
    {
        EntryDate = DateTime.Now; // Set entry date to current date
        Prompt = prompt; // Set the prompt for the entry
        Text = text; // Set the text for the entry
        Tags = tags; // Optional tags for the entry
    }

    // Method to display the entry information
    public string DisplayEntry()
    {
        return $"{EntryDate.ToShortDateString()} - Prompt: {Prompt}\n{Text}\nTags: {Tags}\n";
    }
}
