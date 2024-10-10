// Program.cs
using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptures = LoadScriptures();
        Scripture scripture = GetRandomScripture(scriptures);
        
        int hiddenWordCount = 0;
        bool allWordsHidden = false;

        while (true)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press Enter to hide a word, type 'reset' to load a new scripture, or type 'quit' to exit.");

            string input = Console.ReadLine().ToLower();
            if (input == "quit")
                break;

            if (input == "reset")
            {
                // Load a new random scripture and reset the hidden word count
                scripture = GetRandomScripture(scriptures);
                hiddenWordCount = 0;
                continue;
            }

            // Incrementally hide words
            allWordsHidden = scripture.HideNextWord();

            if (allWordsHidden)
            {
                Console.WriteLine("All words are hidden! Press Enter to exit.");
                Console.ReadLine();
                break;
            }

            hiddenWordCount++;
            Console.WriteLine($"Hidden Words: {hiddenWordCount}");
        }
    }

    static List<Scripture> LoadScriptures()
    {
        // For now, returning a static list of scriptures
        return new List<Scripture>
        {
            new Scripture(new Reference("John", 3, new List<int> { 16 }), new List<Word>
            {
                new Word("For"), new Word("God"), new Word("so"), new Word("loved"), new Word("the"), new Word("world")
            }),
            new Scripture(new Reference("Genesis", 1, new List<int> { 1 }), new List<Word>
            {
                new Word("In"), new Word("the"), new Word("beginning"), new Word("God"), new Word("created"), new Word("the"), new Word("heavens"), new Word("and"), new Word("the"), new Word("earth")
            })
        };
    }

    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        Random random = new Random();
        int index = random.Next(scriptures.Count);
        return scriptures[index];
    }
}

// Scripture.cs
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _currentWordIndex = 0;

    public Scripture(Reference reference, List<Word> words)
    {
        _reference = reference;
        _words = words;
    }

    public void Display()
    {
        Console.WriteLine(_reference.ToString());
        foreach (var word in _words)
        {
            Console.Write(word.GetDisplayText() + " ");
        }
        Console.WriteLine();
    }

    public bool HideNextWord()
    {
        if (_currentWordIndex < _words.Count)
        {
            _words[_currentWordIndex].Hide();
            _currentWordIndex++;
            return false; // Words are still remaining
        }
        return true; // All words hidden
    }
}

// Reference.cs
class Reference
{
    private string _book;
    private int _chapter;
    private List<int> _verses;

    public Reference(string book, int chapter, List<int> verses)
    {
        _book = book;
        _chapter = chapter;
        _verses = verses;
    }

    public override string ToString()
    {
        return $"{_book} {_chapter}:{string.Join(",", _verses)}";
    }
}

// Word.cs
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public string GetDisplayText()
    {
        return _isHidden ? "____" : _text;
    }

    public void Hide()
    {
        _isHidden = true;
    }
}
