using System;
using System.IO;
using System.Collections.Generic;

public static class ScriptureLibrary
{
    public static Scripture GetRandomScripture(string filePath)
    {
        var lines = File.ReadAllLines(filePath);
        Random rand = new Random();
        string line = lines[rand.Next(lines.Length)];

        string[] parts = line.Split('|');
        string referencePart = parts[0].Trim();
        string text = parts[1].Trim();

        // Handle "Book Chapter:Verse" or "Book Chapter:Verse-Verse"
        string[] refParts = referencePart.Split(' ');
        string book = refParts[0];
        string[] chapterAndVerse = refParts[1].Split(':');
        int chapter = int.Parse(chapterAndVerse[0]);

        if (chapterAndVerse[1].Contains('-'))
        {
            string[] verses = chapterAndVerse[1].Split('-');
            return new Scripture(new Reference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1])), text);
        }
        else
        {
            return new Scripture(new Reference(book, chapter, int.Parse(chapterAndVerse[1])), text);
        }
    }
}
