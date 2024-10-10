// Program.cs
using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // Load the list of scriptures from the LoadScriptures method
        List<Scripture> scriptures = LoadScriptures();

        // Select a random scripture to start with
        Scripture scripture = GetRandomScripture(scriptures);

        // Keep track of the number of hidden words
        int hiddenWordCount = 0;

        // Flag to check if all words are hidden
        bool allWordsHidden = false;

        // Enhancement: Display program instructions at the start
        DisplayInstructions();

        // Main loop to control hiding words or executing commands
        while (true)
        {
            Console.Clear(); // Clear the console screen for a cleaner interface
            scripture.Display(); // Display the current scripture

            // User instructions for available actions
            Console.WriteLine("Press Enter to hide a word, type 'reset' to load a new scripture, 'search' to find a scripture, or 'quit' to exit.");

            // Take user input
            string input = Console.ReadLine().ToLower();
            if (input == "quit") // Exit if the user types 'quit'
                break;

            if (input == "reset") // Reset the scripture with a new random one if 'reset' is typed
            {
                scripture = GetRandomScripture(scriptures);
                hiddenWordCount = 0;
                continue;
            }

            if (input == "search") // Enhancement: Allow users to search scriptures based on keywords/tags
            {
                SearchScripture(scriptures); // Perform search functionality
                continue;
            }

            // Incrementally hide words from the scripture one at a time
            allWordsHidden = scripture.HideNextWord();

            // Check if all words have been hidden
            if (allWordsHidden)
            {
                Console.WriteLine("All words are hidden! Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            hiddenWordCount++; // Increment the count of hidden words
            Console.WriteLine($"Hidden Words: {hiddenWordCount}"); // Display the hidden word count
        }
    }

    // LoadScriptures method returns a list of static scriptures with tagging categories for extra organization.
    static List<Scripture> LoadScriptures()
    {
        return new List<Scripture>
        {
            // Scripture with a tag category of 'Love' and 'Salvation'
            new Scripture(new Reference("John", 3, new List<int> { 16 }), new List<Word>
            {
                new Word("For"), new Word("God"), new Word("so"), new Word("loved"), new Word("the"), new Word("world"), new Word("that"), new Word("He"), new Word("gave"), new Word("His"), new Word("one"), new Word("and"), new Word("only"), new Word("Son")
            }, new List<string> { "Love", "Salvation" }),

            // Scripture with a tag category of 'Creation' and 'Beginnings'
            new Scripture(new Reference("Genesis", 1, new List<int> { 1 }), new List<Word>
            {
                new Word("In"), new Word("the"), new Word("beginning"), new Word("God"), new Word("created"), new Word("the"), new Word("heavens"), new Word("and"), new Word("the"), new Word("earth")
            }, new List<string> { "Creation", "Beginnings" })
        };
    }

    // Randomly selects a scripture from the list
    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }

    // Enhancement: Display instructions to guide users on how to use the program.
    static void DisplayInstructions()
    {
        Console.WriteLine("Welcome to the Scripture Memorizer Program!");
        Console.WriteLine("Press Enter to hide a word, type 'reset' to load a new scripture, 'search' to find a scripture, or 'quit' to exit.");
        Console.ReadLine(); // Pause for the user to press Enter before continuing
    }

    // Enhancement: Allow users to search for scriptures based on keywords or categories.
    static void SearchScripture(List<Scripture> scriptures)
    {
        Console.WriteLine("Enter a keyword or category to search:");
        string keyword = Console.ReadLine().ToLower();

        // Search for scriptures that match the keyword in the reference or tags
        var foundScriptures = scriptures.Where(s => s.Reference.ToString().ToLower().Contains(keyword) || s.Tags.Any(tag => tag.ToLower().Contains(keyword))).ToList();

        if (foundScriptures.Count == 0)
        {
            Console.WriteLine("No scriptures found with that keyword."); // Inform user if no scriptures match
        }
        else
        {
            Console.WriteLine("Found Scriptures:");
            foreach (var scripture in foundScriptures)
            {
                scripture.Display(); // Display each matching scripture
            }
        }

        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine(); // Pause for user interaction
    }
}

// Scripture.cs
class Scripture
{
    private Reference _reference; // The reference (book, chapter, verse) of the scripture
    private List<Word> _words; // List of words that make up the scripture
    private List<string> _tags; // Enhancement: Tags for categorization and easier searching
    private int _currentWordIndex = 0; // Track the current word being hidden
    private Random _random = new Random(); // Random number generator for hiding words

    public Scripture(Reference reference, List<Word> words, List<string> tags)
    {
        _reference = reference;
        _words = words;
        _tags = tags; // Initialize tags for categorization
    }

    // Display the scripture with visible and hidden words
    public void Display()
    {
        Console.WriteLine(_reference.ToString()); // Display the reference (e.g., John 3:16)
        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " "); // Show each word or hide it based on its state
        }
        Console.WriteLine();
    }

    // Hide the next word randomly
    public bool HideNextWord()
    {
        if (_currentWordIndex < _words.Count)
        {
            int wordToHideIndex = _random.Next(_words.Count); // Randomly select a word to hide
            while (_words[wordToHideIndex].IsHidden)
            {
                wordToHideIndex = _random.Next(_words.Count); // Ensure we only hide unhidden words
            }
            _words[wordToHideIndex].Hide(); // Hide the selected word
            _currentWordIndex++; // Increment the hidden word count
            return false;
        }
        return true; // Return true if all words are hidden
    }

    public Reference Reference => _reference; // Getter for the reference
    public List<string> Tags => _tags; // Enhancement: Getter for the tags
}

// Reference.cs
class Reference
{
    private string _book; // Book of the scripture (e.g., John)
    private int _chapter; // Chapter number
    private List<int> _verses; // Verses (can handle multiple verses)

    public Reference(string book, int chapter, List<int> verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }

    public override string ToString()
    {
        return $"{_book} {_chapter}:{string.Join(",", _verses)}"; // Format the reference (e.g., John 3:16)
    }
}

// Word.cs
class Word
{
    private string _text; // The word text itself
    private bool _isHidden; // Boolean flag to track if the word is hidden or not

    public Word(string text)
    {
        _text = text;
        _isHidden = false; // Initially, the word is not hidden
    }

    // Return either the word or a placeholder if it's hidden
    public string GetDisplayText()
    {
        return _isHidden ? "____" : _text; // Show hidden words as underscores
    }

    // Hide the word by setting the flag to true
    public void Hide()
    {
        _isHidden = true;
    }

    public bool IsHidden => _isHidden; // Getter for checking if the word is hidden
}
