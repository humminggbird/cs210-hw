using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
private List<Goal> _goals;
    private int _score;

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    private int GetLevel()
    {
        return (_score / 1000) + 1;
    }

    private string GetLevelTitle()
    {
        int level = GetLevel();
        if (level <= 2)  return "Rookie";
        if (level <= 5)  return "Rising";
        if (level <= 10) return "Goal Crusher";
        if (level <= 20) return "Legendary";
        return "Ultimate";
    }

    // This is the main loop for GoalManager called by Program.cs
    public void Start()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine($"\n****************************");
            Console.WriteLine($"  Level {GetLevel()} — {GetLevelTitle()}");
            Console.WriteLine($"  Score: {_score} points");
            Console.WriteLine($"****************************");

            Console.WriteLine("\n   MENU ");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Record Event");
            Console.WriteLine("  4. Save Goals");
            Console.WriteLine("  5. Load Goals");
            Console.WriteLine("  6. Quit");
            Console.Write("\n  Select a choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1": CreateGoal();      break;
                case "2": ListGoalDetails(); break;
                case "3": RecordEvent();     break;
                case "4": SaveGoals();       break;
                case "5": LoadGoals();       break;
                case "6": running = false;   break;
                default:
                    Console.WriteLine("  Invalid choice. Please try again.");
                    break;
            }
        }

        Console.WriteLine("\n  Thanks for using Eternal Quest! Byeeee.");
    }

    // Displays current score and level
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"\n  Score: {_score} | Level: {GetLevel()} ({GetLevelTitle()})");
    }

    // Lists goal names with their index.
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_goals[i].GetName()}");
        }
    }

    // Lists full goal details including checkbox and progress
    public void ListGoalDetails()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\n  No goals yet. Create one first!");
            return;
        }

        Console.WriteLine("\n  === Your Goals ===");
        for (int i = 0; i < _goals.Count; i++)
        {

            Console.WriteLine($"  {i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    // Prompt user to create a new goal of their chosen type
    public void CreateGoal()
    {
        Console.WriteLine("\n  What type of goal would you like to create?");
        Console.WriteLine("  1. Simple Goal   (one-time accomplishment)");
        Console.WriteLine("  2. Eternal Goal  (ongoing habit, never ends)");
        Console.WriteLine("  3. Checklist Goal (must be done X times)");
        Console.WriteLine("  4. Negative Goal  (bad habit to track — loses points)");
        Console.Write("  Choice: ");
        string type = Console.ReadLine();

        Console.Write("  Short Name: ");
        string name = Console.ReadLine();

        Console.Write("  Description: ");
        string description = Console.ReadLine();

        Console.Write("  Points per event: ");
        int points = int.Parse(Console.ReadLine());

        if (type == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
            Console.WriteLine($"\n  Simple goal \"{name}\" created!");
        }
        else if (type == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
            Console.WriteLine($"\n  Eternal goal \"{name}\" created!");
        }
        else if (type == "3")
        {
            Console.Write("  Target (how many times to complete): ");
            int target = int.Parse(Console.ReadLine());
            Console.Write("  Bonus points when finished: ");
            int bonus = int.Parse(Console.ReadLine());
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
            Console.WriteLine($"\n  Checklist goal \"{name}\" created! Finish it {target} times for a {bonus}-point bonus!");
        }
        else if (type == "4")
        {
            _goals.Add(new NegativeGoal(name, description, points));
            Console.WriteLine($"\n  Negative goal \"{name}\" added. Try to avoid this one!");
        }
        else
        {
            Console.WriteLine("  Unknown goal type. No goal created.");
        }
    }

    // Asks which goal was accomplished, then records it do dertermine whether to add or subtract points.
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("\n  No goals to record. Create one first!");
            return;
        }

        Console.WriteLine("\n  Which goal did you accomplish (or slip on)?");
        ListGoalDetails();
        Console.Write("  Choice: ");

        if (!int.TryParse(Console.ReadLine(), out int index) || index < 1 || index > _goals.Count)
        {
            Console.WriteLine("  Invalid selection.");
            return;
        }

        Goal goal = _goals[index - 1];

        // This is to prevent the recording of a SimpleGoal that's already done
        if (goal is SimpleGoal && goal.IsComplete())
        {
            Console.WriteLine($"\n  \"{goal.GetName()}\" is already complete!");
            return;
        }

        bool wasComplete = goal.IsComplete();

        goal.RecordEvent();

        if (goal is NegativeGoal)
        {
            _score -= Math.Abs(goal.GetPoints());
            Console.WriteLine($"\n  Oh no! You lost {goal.GetPoints()} points for \"{goal.GetName()}\".");
            Console.WriteLine($"  Current score: {_score}");
        }
        else
        {
            int earned = goal.GetPoints();
            _score += earned;

            // Check if a ChecklistGoal just hit its target — award bonus
            if (goal is ChecklistGoal cg && !wasComplete && goal.IsComplete())
            {
                int bonus = cg.GetBonus();
                _score += bonus;
                Console.WriteLine($"\n  🎉 CHECKLIST COMPLETE! You earned {earned} + {bonus} bonus = {earned + bonus} points!");
            }
            else
            {
                Console.WriteLine($"\n  Great job! You earned {earned} points for \"{goal.GetName()}\"!");
            }

            Console.WriteLine($"  Current score: {_score} | Level: {GetLevel()} ({GetLevelTitle()})");
        }
    }

    // Saves all goals and the current score to a file name provided by the user.
    public void SaveGoals()
    {
        Console.Write("\n  Enter filename to save: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (Goal g in _goals)
            {
                // Polymorphism: each goal type knows how to represent itself as a string
                writer.WriteLine(g.GetStringRepresentation());
            }
        }

        Console.WriteLine($"  Goals saved to \"{filename}\" successfully!");
    }

    // Loads goals and score from a previously saved file
    public void LoadGoals()
    {
        Console.Write("\n  Enter filename to load: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine($"  File \"{filename}\" not found.");
            return;
        }

        string[] lines = File.ReadAllLines(filename);
        _score = int.Parse(lines[0]);
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            // Split on colon to get type vs data
            string[] parts = lines[i].Split(':');
            string type = parts[0];
            string[] data = parts[1].Split(',');

            // Trim whitespace from each value for safety
            for (int j = 0; j < data.Length; j++)
                data[j] = data[j].Trim();

            if (type == "SimpleGoal")
            {
                SimpleGoal g = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                if (bool.Parse(data[3])) g.RecordEvent(); // Restore completion state
                _goals.Add(g);
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (type == "ChecklistGoal")
            {
                ChecklistGoal g = new ChecklistGoal(
                    data[0], data[1],
                    int.Parse(data[2]),
                    int.Parse(data[4]),
                    int.Parse(data[5])
                );
                int timesCompleted = int.Parse(data[3]);
                for (int j = 0; j < timesCompleted; j++) g.RecordEvent(); // Restore count
                _goals.Add(g);
            }
            else if (type == "NegativeGoal")
            {
                _goals.Add(new NegativeGoal(data[0], data[1], int.Parse(data[2])));
            }
        }

        Console.WriteLine($"  Goals loaded from \"{filename}\"! Score restored to {_score}.");
    }
}