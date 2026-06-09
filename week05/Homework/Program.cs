using System;

class Program
{
    static void Main(string[] args)
    {
        MathAssignment math = new MathAssignment("Joel Dadzie", "Geometry", "6.4", "5-18");

        Console.WriteLine(math.GetSummary());
        Console.WriteLine(math.GetHomeworkList());

        Console.WriteLine();

        WritingAssignment writing = new WritingAssignment("Joel Dadzie", "Geography", "The Impact of Climate on Human Settlement");

        Console.WriteLine(writing.GetSummary());
        Console.WriteLine(writing.GetWritingInformation());
    }
}