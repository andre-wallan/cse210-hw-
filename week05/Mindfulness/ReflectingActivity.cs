using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "What did you learn about yourself?",
        "How did you get started?",
        "How did you feel when it was complete?"
    };

    public ReflectingActivity() : base("Reflecting Activity", "This activity helps you reflect on times you showed strength and resilience.") {}

    public void Run()
    {
        DisplayStartMessage();
        Random rand = new Random();
        Console.WriteLine("\n" + _prompts[rand.Next(_prompts.Count)]);
        Console.WriteLine("Reflect on the following questions:");

        int elapsed = 0;
        while (elapsed < _duration)
        {
            string question = _questions[rand.Next(_questions.Count)];
            Console.WriteLine("\n" + question);
            PauseWithSpinner(5);
            elapsed += 5;
        }

        DisplayEndMessage();
    }
}

