using System;
using System.Collections.Generic;
using System.Threading;
using System.IO;

public abstract class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;
    protected static Random _random = new Random();

    public int GetDuration()
    {
        return _duration;
    }

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void Start()
    {
        DisplayStartingMessage();
        SetDuration();
        PrepareToBegin();
    }

    private void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
    }

    private void SetDuration()
    {
        while (true)
        {
            Console.Write("How long, in seconds, would you like for your session? ");
            if (int.TryParse(Console.ReadLine(), out int duration) && duration > 0)
            {
                _duration = duration;
                break;
            }
            Console.WriteLine("Please enter a valid positive number.");
        }
    }

    private void PrepareToBegin()
    {
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(5);
    }

    public void End()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine();
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }

    protected void ShowSpinner(int seconds)
    {
        List<string> spinnerChars = new List<string> { "|", "/", "-", "\\" };
        DateTime endTime = DateTime.Now.AddSeconds(seconds);

        int i = 0;
        while (DateTime.Now < endTime)
        {
            string currentSpin = spinnerChars[i];
            Console.Write(currentSpin);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i = (i + 1) % spinnerChars.Count;
        }
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    public abstract void Run();
}

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", 
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        Start();
        
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in...");
            ShowCountDown(4);
            Console.Write("\nNow breathe out...");
            ShowCountDown(6);
            Console.WriteLine();
        }

        End();
    }
}

public class ReflectionActivity : Activity
{
    private List<string> _prompts;
    private List<string> _questions;
    private HashSet<int> _usedPrompts;
    private HashSet<int> _usedQuestions;

    public ReflectionActivity() : base("Reflection Activity", 
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        InitializeLists();
        _usedPrompts = new HashSet<int>();
        _usedQuestions = new HashSet<int>();
    }

    private void InitializeLists()
    {
        _prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you overcame a significant challenge."
        };

        _questions = new List<string>
        {
            "Why was this experience meaningful to you?",
            "Have you ever done anything like this before?",
            "How did you get started?",
            "How did you feel when it was complete?",
            "What made this time different than other times when you were not as successful?",
            "What is your favorite thing about this experience?",
            "What could you learn from this experience that applies to other situations?",
            "What did you learn about yourself through this experience?",
            "How can you keep this experience in mind in the future?"
        };
    }

    public override void Run()
    {
        Start();

        Console.WriteLine("\nConsider the following prompt:\n");
        string prompt = GetRandomPrompt();
        Console.WriteLine($"--- {prompt} ---\n");
        
        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("\nNow ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.Clear();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
        }

        End();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count >= _prompts.Count)
            _usedPrompts.Clear();

        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        } while (_usedPrompts.Contains(index));

        _usedPrompts.Add(index);
        return _prompts[index];
    }

    private string GetRandomQuestion()
    {
        if (_usedQuestions.Count >= _questions.Count)
            _usedQuestions.Clear();

        int index;
        do
        {
            index = _random.Next(_questions.Count);
        } while (_usedQuestions.Contains(index));

        _usedQuestions.Add(index);
        return _questions[index];
    }
}

public class ListingActivity : Activity
{
    private List<string> _prompts;
    private HashSet<int> _usedPrompts;

    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        InitializePrompts();
        _usedPrompts = new HashSet<int>();
    }

    private void InitializePrompts()
    {
        _prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt the Holy Ghost this month?",
            "Who are some of your personal heroes?",
            "What are things you've accomplished this week?",
            "What are small acts of kindness you've witnessed recently?"
        };
    }

    public override void Run()
    {
        Start();

        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("\nYou may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();

        List<string> responses = GetListFromUser();
        
        Console.WriteLine($"\nYou listed {responses.Count} items!");

        End();
    }

    private string GetRandomPrompt()
    {
        if (_usedPrompts.Count >= _prompts.Count)
            _usedPrompts.Clear();

        int index;
        do
        {
            index = _random.Next(_prompts.Count);
        } while (_usedPrompts.Contains(index));

        _usedPrompts.Add(index);
        return _prompts[index];
    }

    private List<string> GetListFromUser()
    {
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(response))
            {
                items.Add(response);
            }
        }

        return items;
    }
}

public class GratitudeActivity : Activity
{
    private readonly string _journalFile = "gratitude_journal.txt";

    public GratitudeActivity() : base("Gratitude Activity",
        "This activity will help you cultivate gratitude by reflecting deeply on your blessings and recording them in a journal.")
    {
    }

    public override void Run()
    {
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        List<string> entries = new List<string>();

        Console.WriteLine("\nTake a moment to write down things you're grateful for.");
        Console.WriteLine("Press Enter after each entry. Double Enter to finish before the time is up.\n");

        while (DateTime.Now < endTime)
        {
            Console.Write($"Time remaining: {(endTime - DateTime.Now).Seconds} seconds > ");
            string entry = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(entry))
                break;

            entries.Add(entry);
        }

        SaveToJournal(entries);
        Console.WriteLine($"\nYou recorded {entries.Count} gratitude entries!");

        End();
    }

    private void SaveToJournal(List<string> entries)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        List<string> journalEntry = new List<string>
        {
            $"\nGratitude Journal Entry - {timestamp}",
            "----------------------------------------"
        };
        journalEntry.AddRange(entries.Select((entry, i) => $"{i + 1}. {entry}"));
        journalEntry.Add("----------------------------------------\n");

        File.AppendAllLines(_journalFile, journalEntry);
    }
}

class Program
{
    private static string ACTIVITY_LOG = "activity_log.txt";
    
    static void Main(string[] args)
    {
        Dictionary<string, int> activityLog = LoadActivityLog();
        
        while (true)
        {
            Console.Clear();
            DisplayMenu(activityLog);

            string choice = Console.ReadLine();
            Activity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    activity = new GratitudeActivity();
                    break;
                case "5":
                    SaveActivityLog(activityLog);
                    return;
                default:
                    Console.WriteLine("\nInvalid choice. Please try again.");
                    Thread.Sleep(2000);
                    continue;
            }

            Console.Clear();
            activity.Run();
            UpdateActivityLog(activityLog, activity);
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }

    private static void DisplayMenu(Dictionary<string, int> log)
    {
        Console.WriteLine("Mindfulness Program");
        Console.WriteLine("==================");
        Console.WriteLine("\nActivity Statistics:");
        foreach (var entry in log)
        {
            Console.WriteLine($"{entry.Key}: {entry.Value} seconds total");
        }
        
        Console.WriteLine("\nMenu Options:");
        Console.WriteLine("1. Start breathing activity");
        Console.WriteLine("2. Start reflection activity");
        Console.WriteLine("3. Start listing activity");
        Console.WriteLine("4. Start gratitude activity");
        Console.WriteLine("5. Quit");
        Console.Write("\nSelect a choice from the menu: ");
    }

    private static Dictionary<string, int> LoadActivityLog()
    {
        var log = new Dictionary<string, int>
        {
            {"Breathing Activity", 0},
            {"Reflection Activity", 0},
            {"Listing Activity", 0},
            {"Gratitude Activity", 0}
        };

        if (File.Exists(ACTIVITY_LOG))
        {
            foreach (string line in File.ReadAllLines(ACTIVITY_LOG))
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2 && int.TryParse(parts[1], out int duration))
                {
                    log[parts[0]] = duration;
                }
            }
        }

        return log;
    }

    private static void SaveActivityLog(Dictionary<string, int> log)
    {
        List<string> lines = log.Select(kvp => $"{kvp.Key}:{kvp.Value}").ToList();
        File.WriteAllLines(ACTIVITY_LOG, lines);
    }

    private static void UpdateActivityLog(Dictionary<string, int> log, Activity activity)
    {
        log[activity.GetType().Name] = log[activity.GetType().Name] + activity.GetDuration();
    }
} 