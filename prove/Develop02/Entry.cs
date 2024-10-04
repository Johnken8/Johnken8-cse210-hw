public class Entry
{
    public DateTime EntryDate { get; set; }
    public string Prompt { get; set; }
    public string Text { get; set; }

    public Entry(string prompt, string text)
    {
        EntryDate = DateTime.Now;
        Prompt = prompt;
        Text = text;
    }

    public string DisplayEntry()
    {
        return $"{EntryDate.ToShortDateString()} - Prompt: {Prompt}\n{Text}\n";
    }
}
