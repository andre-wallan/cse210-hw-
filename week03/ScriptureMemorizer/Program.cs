using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Scripture Memorizer!");
        Console.Write("How many words do you want to hide per round? (e.g., 3): ");
        int wordsToHide = int.TryParse(Console.ReadLine(), out int n) ? n : 3;

        Scripture scripture = ScriptureLibrary.GetRandomScripture("scriptures.txt");

        DateTime startTime = DateTime.Now;

        while (!scripture.AllWordsHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nPress Enter to hide words, type 'hint' for a hint, or type 'quit' to exit.");
            string input = Console.ReadLine().Trim().ToLower();

            if (input == "quit")
                break;

            if (input == "hint")
            {
                Console.WriteLine("\nHint: " + scripture.GetHintText());
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
                continue;
            }

            scripture.HideRandomWords(wordsToHide);
        }

        Console.Clear();
        Console.WriteLine("Final Scripture:\n");
        Console.WriteLine(scripture.GetDisplayText());

        TimeSpan duration = DateTime.Now - startTime;
        Console.WriteLine($"\nMemorization Time: {duration.TotalSeconds:F1} seconds");

        ProgressTracker.SaveProgress(scripture.Reference.GetDisplayText());

        Console.WriteLine("\nThank you for using Scripture Memorizer!");
    }
}
