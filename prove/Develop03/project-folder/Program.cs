using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart and lean not unto thine own understanding. In all thy ways acknowledge him and he shall direct thy paths."
            ),
            new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life."
            ),
            new Scripture(
                new Reference("Mosiah", 2, 17),
                "When ye are in the service of your fellow beings ye are only in the service of your God."
            )
        };

        bool addingScriptures = true;

        while (addingScriptures)
        {
            Console.Clear();
            Console.WriteLine("Scripture Memorizer");
            Console.WriteLine("1. Choose a scripture");
            Console.WriteLine("2. Add a new scripture");
            Console.Write("Choose an option: ");

            string menuChoice = Console.ReadLine();

            if (menuChoice == "1")
            {
                addingScriptures = false;
            }
            else if (menuChoice == "2")
            {
                Console.Write("Book: ");
                string book = Console.ReadLine();

                Console.Write("Chapter: ");
                int chapter = int.Parse(Console.ReadLine());

                Console.Write("Start verse: ");
                int startVerse = int.Parse(Console.ReadLine());

                Console.Write("End verse, or press enter if it is only one verse: ");
                string endVerseInput = Console.ReadLine();

                Console.Write("Scripture text: ");
                string text = Console.ReadLine();

                Reference reference;

                if (endVerseInput == "")
                {
                    reference = new Reference(book, chapter, startVerse);
                }
                else
                {
                    int endVerse = int.Parse(endVerseInput);
                    reference = new Reference(book, chapter, startVerse, endVerse);
                }

                scriptures.Add(new Scripture(reference, text));

                Console.WriteLine("\nScripture added! Press enter to continue.");
                Console.ReadLine();
            }
        }

        Console.Clear();
        Console.WriteLine("Choose a scripture:");

        for (int i = 0; i < scriptures.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {scriptures[i].GetReferenceText()}");
        }

        Console.Write("Enter your choice: ");
        int choice = int.Parse(Console.ReadLine());

        Scripture selectedScripture = scriptures[choice - 1];

        int wordsToHide = 3;

        while (!selectedScripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.GetDisplayText());
            Console.WriteLine("\nPress enter to hide words or type 'quit' to exit.");

            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            selectedScripture.HideRandomWords(wordsToHide);

            wordsToHide++;
        }

        Console.Clear();
        Console.WriteLine(selectedScripture.GetDisplayText());
    }
}