using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(new Reference("John", 3, 16), "For God so loved the world that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
            new Scripture(new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.")
        };

        Random rand = new Random();
        Scripture selectedScripture = scriptures[rand.Next(scriptures.Count)];

        while (!selectedScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");
            string input = Console.ReadLine();
            if (input.ToLower() == "quit") break;
            selectedScripture.HideRandomWords(3);
        }
    }
}

class Reference
{
    public string Book { get; }
    public int Chapter { get; }
    public int StartVerse { get; }
    public int? EndVerse { get; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse == null ? $"{Book} {Chapter}:{StartVerse}" : $"{Book} {Chapter}:{StartVerse}-{EndVerse}";
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
    public Reference Reference { get; }
    private List<Word> Words { get; }

    public Scripture(Reference reference, string text)
    {
        Reference = reference;
        Words = text.Split(' ').Select(word => new Word(word)).ToList();
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
