using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture selectedScripture = scriptures[choice - 1];

        int wordsToHide = 3;

        while (!selectedScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");
            
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;

            selectedScripture.HideRandomWords(wordsToHide);

            wordsToHide++;
        }
        }
}

class Reference
{
    private string _book;
    private int _chapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    public override string ToString()
    {
        if (_startVerse == _endVerse)
            return $"{_book} {_chapter}:{_startVerse}";
        else
            return $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}

class Word
{
    public string Text { get; }
    public bool IsHidden { get; private set; }

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide() => IsHidden = true;

    public override string ToString() => IsHidden ? "_____" : Text;
}

class Scripture
{
    private List<Scripture> scriptures;
    public Reference Reference { get; private set; }
    private List<Word> Words { get; }
    
    public Scripture()
    {
        scriptures = new List<Scripture>();
    }
    
    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
    }

    public void AddScripture(Reference reference, string text)
    {
        scriptures.Add(new Scripture(reference, text));
    }
    
    public List<Scripture> GetAllScriptures()
    {
        return scriptures;
    }

    public void HideRandomWords(int count)
    {
        Random rand = new Random();
        var availableWords = Words.Where(w => !w.IsHidden).ToList();
        for (int i = 0; i < count && availableWords.Any(); i++)
        {
            int index = rand.Next(availableWords.Count);
            availableWords[index].Hide();
            availableWords.RemoveAt(index);
        }
    }

    public bool AllWordsHidden() => Words.All(word => word.IsHidden);

    public string GetDisplayText()
    {
        return $"{Reference}\n{string.Join(" ", Words)}";
    }
}
