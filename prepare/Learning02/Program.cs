using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Date { get; set; }
    public string Prompt { get; set; }
    public string Response { get; set; }

    public Entry(string prompt, string response)
    {
        Date = DateTime.Now.ToString("yyyy-MM-dd");
        Prompt = prompt;
        Response = response;
    }

    public override string ToString()
    {
        return $"Date: {Date}\nPrompt: {Prompt}\nResponse: {Response}\n";
    }

    public string ToFileFormat()
    {
        return $"{Date}|{Prompt}|{Response}";
    }

    public static Entry FromFileFormat(string line)
    {
        var parts = line.Split('|');
        return new Entry(parts[1], parts[2]) { Date = parts[0] };
    }
}

class Journal
{
    private List<Entry> entries = new List<Entry>();
    private List<string> prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?"
    };

    public void WriteEntry()
    {
        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine(prompt);
        string response = Console.ReadLine();
        entries.Add(new Entry(prompt, response));
    }

    public void DisplayJournal()
    {
        foreach (var entry in entries)
        {
            Console.WriteLine(entry);
        }
    }

    public void SaveToFile()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        File.WriteAllLines(filename, entries.ConvertAll(e => e.ToFileFormat()));
    }

    public void LoadFromFile()
    {
        Console.Write("Enter filename: ");
        string filename = Console.ReadLine();
        if (File.Exists(filename))
        {
            entries = new List<Entry>();
            foreach (var line in File.ReadAllLines(filename))
            {
                entries.Add(Entry.FromFileFormat(line));
            }
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}

class Program
{
    static void Main()
    {
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("1. Write Entry\n2. Display Journal\n3. Save to File\n4. Load from File\n5. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1": journal.WriteEntry(); break;
                case "2": journal.DisplayJournal(); break;
                case "3": journal.SaveToFile(); break;
                case "4": journal.LoadFromFile(); break;
                case "5": return;
                default: Console.WriteLine("Invalid choice."); break;
            }
        }
    }
}
