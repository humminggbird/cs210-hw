using System;
using System.Collections.Generic;

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
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public ReflectingActivity() : base(
        "Reflection Activity",
        "This activity will help you reflect on times in your life when you have shown strength\nand resilience. This will help you recognize the power you have and how you can use it\nin other aspects of your life.")
    {
    }

    public string GetRandomPrompt()
    {
        Random rand = new Random();
        return _prompts[rand.Next(_prompts.Count)];
    }

    public string GetRandomQuestion()
    {
        Random rand = new Random();
        return _questions[rand.Next(_questions.Count)];
    }

    public override void Run()
    {
        DisplayStartingMessage();

        Console.WriteLine($"\n Reflect on the following prompt");
        Console.WriteLine($"\n> {GetRandomPrompt()}\n");
        Console.WriteLine("When you have something in mind, press Enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.WriteLine("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();

        // Shuffle questions so they appear in random order
        List<string> questions = new List<string>(_questions);
        Random rand = new Random();
        for (int i = questions.Count - 1; i > 0; i--)
        {
            int j = rand.Next(i + 1);
            string temp = questions[i];
            questions[i] = questions[j];
            questions[j] = temp;
        }

        int questionIndex = 0;
        int elapsed = 0;

        while (elapsed < _duration)
        {
            // Reshuffle when we run out of questions
            if (questionIndex >= questions.Count)
            {
                for (int i = questions.Count - 1; i > 0; i--)
                {
                    int j = rand.Next(i + 1);
                    string temp = questions[i];
                    questions[i] = questions[j];
                    questions[j] = temp;
                }
                questionIndex = 0;
            }

            Console.Write($"\n> {questions[questionIndex]} ");
            questionIndex++;

            int pauseTime = 5;
            if (elapsed + pauseTime > _duration)
                pauseTime = _duration - elapsed;

            ShowSpinner(pauseTime);
            elapsed += pauseTime;
        }

        Console.WriteLine();
        DisplayEndingMessage();
    }
}