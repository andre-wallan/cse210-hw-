using System;

public class Activity
{
    protected string _name;
    protected string _description;
    protected int _duration;

    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void SetDurationFromUser()
    {
        Console.Write("Enter duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        SetDurationFromUser();
        Console.WriteLine("Prepare to begin...");
        PauseWithSpinner(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine("\nWell done!");
        PauseWithSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        PauseWithSpinner(2);
    }

    public void PauseWithSpinner(int seconds)
    {
        string[] spinner = {"|", "/", "-", "\\"};
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    public void PauseWithCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }
}
