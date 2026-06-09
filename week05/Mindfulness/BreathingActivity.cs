using System;

public class BreathingActivity : Activity
{
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly.\nClear your mind and focus on your breathing.")
    {
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;
        bool breatheIn = true;

        while (elapsed < _duration)
        {
            int pauseTime = 7;
            if (elapsed + pauseTime > _duration)
                pauseTime = _duration - elapsed;

            if (breatheIn)
            {
                Console.WriteLine("\nBreathe in...");
            }
            else
            {
                Console.WriteLine("\nBreathe out...");
            }

            ShowCountdown(pauseTime);
            elapsed += pauseTime;
            breatheIn = !breatheIn;
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}