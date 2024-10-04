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

        while (true)
        {
            Console.Clear();
            scripture.Display();
            Console.WriteLine("Press Enter to hide a word or type 'quit' to exit.");

            string input = Console.ReadLine();
            if (input.ToLower() == "quit")
                break;

            // Incrementally hide words
            if (!scripture.HideNextWord())
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
        // Load scriptures from a file (to be implemented)
    }

    static Scripture GetRandomScripture(List<Scripture> scriptures)
    {
        // Randomly select a scripture (to be implemented)
    }
}

// Scripture.cs
class Scripture
{
    private Reference _reference;
    private List<Word> _words;
    private int _currentWordIndex = 0; // Track which word to hide next

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
            return true; // Successfully hidden a word
        }
        return false; // No more words to hide
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
        // Return formatted reference
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
