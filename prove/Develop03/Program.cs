using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        Scripture scriptureCollection = new Scripture();
        
        Console.WriteLine("Enter scriptures (format: Book Chapter:Verse[-EndVerse] Text). Type 'done' when finished:");
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "done") break;
            
            var parts = input.Split(new[] { ' ' }, 2);
            if (parts.Length < 2) continue;
            
            string referencePart = parts[0];
            string text = parts[1];
            
            var refParts = referencePart.Split(new[] { ' ', ':', '-' });
            if (refParts.Length < 2) continue;
            
            string book = refParts[0];
            int chapter = int.Parse(refParts[1]);
            int startVerse = int.Parse(refParts[2]);
            int? endVerse = refParts.Length > 3 ? int.Parse(refParts[3]) : (int?)null;
            
            scriptureCollection.AddScripture(new Reference(book, chapter, startVerse, endVerse), text);
        }
        
        Console.WriteLine("Choose a scripture to study:");
        var scriptures = scriptureCollection.GetAllScriptures();
        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].Reference}");
        }
        
        int choice;
        while (!int.TryParse(Console.ReadLine(), out choice) || choice < 1 || choice > scriptures.Count)
        {
            Console.WriteLine("Invalid choice. Please enter a valid number.");
        }
        
        Scripture selectedScripture = scriptures[choice - 1];
        
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
