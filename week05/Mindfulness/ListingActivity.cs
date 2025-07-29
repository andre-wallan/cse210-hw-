using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> _userResponses = new List<string>();

    public ListingActivity() : base("Listing Activity", "This activity helps you reflect on the good by listing positive things in your life.") {}

    public void Run()
    {
        DisplayStartMessage();
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("You may begin listing in: ");
        PauseWithCountdown(3);

        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            _userResponses.Add(input);
        }

        Console.WriteLine($"You listed {_userResponses.Count} items.");
        DisplayEndMessage();
    }
}