using System;
using System.IO;

public static class ProgressTracker
{
    private static string _filePath = "UserProgress.txt";

    public static void SaveProgress(string referenceText)
    {
        using (StreamWriter writer = new StreamWriter(_filePath, true))
        {
            writer.WriteLine($"{DateTime.Now}: Memorized {referenceText}");
        }
    }
}
