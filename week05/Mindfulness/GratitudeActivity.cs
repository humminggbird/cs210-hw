using System;
using System.Collections.Generic;

public class GratitudeActivity : Activity
{
    private List<string> _prompts = new List<string>
    {
        "How has someone changed your life so far this year?",
        "Who has made a difference in your life recently?",
        "What is something about your health that you are grateful for?",
        "What is a challenge you faced so far this year that made you stronger?",
        "What is something beautiful you noticed today?"
    };

    public GratitudeActivity() : base(
        "Gratitude Activity",
        "This activity will help you focus on the positive by guiding you to think about\nthings you are grateful for. Gratitude can shift your mindset and improve your mood.")
    {
    }

    private string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();

        int elapsed = 0;

        while (elapsed < _duration)
        {
            Console.WriteLine($"\n> {GetRandomPrompt()}");
            Console.WriteLine("Think about this for a while...");

            int pauseTime = 10;
            if (elapsed + pauseTime > _duration)
                pauseTime = _duration - elapsed;

            ShowSpinner(pauseTime);
            elapsed += pauseTime;

            if (elapsed < _duration)
            {
                Console.WriteLine("\nWrite down one thing you thought of (press Enter to skip): ");
                Console.Write("> ");
                Console.ReadLine();
            }
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}