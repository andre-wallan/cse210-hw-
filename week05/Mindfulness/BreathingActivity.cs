using System;
using System.Threading;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding you through slow breathing.") {}

    public void Run()
    {
        DisplayStartMessage();

        int elapsed = 0;
        while (elapsed < _duration)
        {
            Console.WriteLine("\nBreathe in...");
            PauseWithCountdown(4);
            Console.WriteLine("Breathe out...");
            PauseWithCountdown(4);
            elapsed += 8;
        }

        DisplayEndMessage();
    }
}

