// How I exceeded the requirements:
// 1. NegativeGoal class: a bad habit tracker that deducts points when recorded.

// 2. I included a level system with titles. The player's score is divided into levels (every 1000
//    points = 1 level). The range is from Rookie, Rising, Goal Crusher, Legendary, to Ultimate. 

// 3. Input validation. I added the RecordEvent() and LoadGoals() methods to handle invalid input instead of the program crashing.

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("  Welcome to Joel's Eternal Quest Program!\n");
        Console.WriteLine("  Track your goals, earn points, and level up your life.\n");

        GoalManager manager = new GoalManager();
        manager.Start();
    }
}
